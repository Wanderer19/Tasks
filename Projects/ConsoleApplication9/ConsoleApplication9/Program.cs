using System;
using System.Data.Common;
using System.Data.OleDb;

namespace ConsoleApplication9
{
    public class Application
    {
        public static void Main()
        {
            MyConsole Console = new MyConsole();
            Console.Run("Data.mdb");
        }
    }

    public class MyConsole
    {
        //Элементы пользовательского интерфейса
        Form MyForm;
        TextBox SQLText;
        Button RunSQL;
        Button CloseForm;
        ListView DataList;

        //Менеджер работы с базой данных
        MyDataManager m_DataManager = new MyDataManager();
        //Признак наличия изменений в базе данных
        bool m_DataChanged = false;

        public void Run(string FileName)
        {
            try
            {
                m_DataManager.Open(FileName);
                m_DataManager.BeginTransaction();
            }
            catch (Exception ex)
            {
                ShowException(ex);
                return;
            }

            //Создание главного окна
            MyForm = new Form();
            MyForm.Width = 400;
            MyForm.Height = 400;
            MyForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            MyForm.StartPosition = FormStartPosition.CenterScreen;
            MyForm.Text = "My SQL Console"; //Заголовок окна
            MyForm.FormClosing += OnClose; //Метод OnClick - обработчки события закрытия формы 

            //Текстовое поле для ввода SQL
            SQLText = new TextBox();
            SQLText.Width = 296;
            SQLText.Height = 200;
            SQLText.Multiline = true; //Включение многострочного режима
            SQLText.ScrollBars = ScrollBars.Vertical; //Включение вертикальной прокрутки
            SQLText.TextChanged += SQLChanged; //Метод SQLChanged - обработчки события изменения текста 

            //Кнопка запуска SQL
            RunSQL = new Button();
            RunSQL.Width = 96;
            RunSQL.Height = 48;
            RunSQL.Text = "Выполнить SQL";
            RunSQL.Enabled = false;
            RunSQL.Click += RunSQLClick; //Метод RunSQLClick - обработчки события нажатия на кнопку 'Выполнить SQL'

            //Кнопка завершения работы
            CloseForm = new Button();
            CloseForm.Width = 96;
            CloseForm.Height = 48;
            CloseForm.Text = "Завершить работу";
            CloseForm.Click += CloseFormClick; //Метод CloseFormClick - обработчки события нажатия на кнопку 'Завершить работу'

            //Список с результатом запроса
            DataList = new ListView();
            DataList.Width = 394;
            DataList.Height = 170;
            DataList.View = View.Details; //Включение отображения колонок в списке
            DataList.GridLines = true; //Показывать горизонтальные линии в списке  

            //Добавление созданных элементов на главное окно
            //и их размещение в точках (X,Y) = (Left, Top)
            MyForm.Controls.Add(SQLText);
            SQLText.Left = 0;
            SQLText.Top = 0;

            MyForm.Controls.Add(RunSQL);
            RunSQL.Left = 298;
            RunSQL.Top = 0;

            MyForm.Controls.Add(CloseForm);
            CloseForm.Left = 298;
            CloseForm.Top = 50;

            MyForm.Controls.Add(DataList);
            DataList.Left = 0;
            DataList.Top = 202;

            //Открытие главного окна в модальном режиме
            MyForm.ShowDialog();
        }

        private void ShowException(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SQLChanged(object sender, EventArgs e)
        {
            RunSQL.Enabled = SQLText.Text.Trim().Length > 0;
        }

        private void RunSQLClick(object sender, EventArgs e)
        {
            string SQL = SQLText.Text.Trim();

            try
            {
                //По первому ключевому слову SQL определяем тип запроса: получение или обновление данных
                if (SQL.StartsWith("select", StringComparison.OrdinalIgnoreCase))
                    MyDataManager.WriteDataReader(m_DataManager.Select(SQL), DataList);
                else
                {
                    DataList.Clear();
                    MessageBox.Show("Обработано " + m_DataManager.Execute(SQL).ToString() + " записей", "Обработка данных");

                    if (!m_DataChanged)
                        //Указываем, что появились изменения и они могут быть сохранены по окончанию работы программы
                        m_DataChanged = true;
                }
            }
            catch (DbException ex)
            {   //Обработка исключительных ситуаций, связанных с синтаксическими ошибками
                ShowException(ex);
            }
        }

        private void CloseFormClick(object sender, EventArgs e)
        {
            MyForm.Close();
        }

        private void OnClose(object sender, EventArgs e)
        {
            if (m_DataChanged)
                if (MessageBox.Show("Сохранить изменения в базе данных?", "Завершение работы", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    m_DataManager.CommitTransaction();
                else
                    m_DataManager.RollbackTransaction();

            try
            {
                m_DataManager.Close();
            }
            catch { }
        }
    }
    //Класс работы с базой данных MS Access
    public class MyDataManager
    {
        //Текущее соединение с базой данных
        private OleDbConnection m_Connection;
        //Текущая транзакция
        private OleDbTransaction m_Transaction;
        //Открытие соединения
        public void Open(string FileName)
        {
            m_Connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName);
            m_Connection.Open();
        }
        //Закрытие соединения
        public void Close()
        {
            m_Connection.Close();
        }
        //Инициализация новой транзакции
        public void BeginTransaction()
        {
            m_Transaction = m_Connection.BeginTransaction();
        }
        //Завершение транзакции с сохранением изменений
        public void CommitTransaction()
        {
            m_Transaction.Commit();
            m_Transaction = null;
        }
        //Завершение транзакции с отменой всех изменений
        public void RollbackTransaction()
        {
            m_Transaction.Rollback();
            m_Transaction = null;
        }
        //Получение данных
        public DbDataReader Select(string SQL)
        {
            return this.CreateCommand(SQL).ExecuteReader();
        }
        //Обновление данных
        public int Execute(string SQL)
        {
            return this.CreateCommand(SQL).ExecuteNonQuery();
        }
        //Вывод результата запроса на консоль
        //Поскольку метод статический, для его вызова создавать экземпляр MyDataManager не требуется
        //Вызов осуществляется через имя типа: MyDataManager.WriteDataReader
        public static void WriteDataReader(DbDataReader Reader, ListView View)
        {
            //Очистить список
            View.Clear();

            //Перед добавлением первой строчки нужно создать колонки
            bool _CreateColumns = true;
            while (Reader.Read())
            {
                //Создание колонок в списке
                if (_CreateColumns)
                {
                    View.Columns.Add("").Width = 20;

                    for (int i = 0; i <= Reader.FieldCount - 1; i++)
                        View.Columns.Add(Reader.GetName(i));

                    _CreateColumns = false;
                }

                ListViewItem NewItem;
                NewItem = View.Items.Add("");

                for (int i = 0; i <= Reader.FieldCount - 1; i++)
                    NewItem.SubItems.Add(Reader.GetValue(i).ToString());
            }
        }
        //Выполнение SQL инструкции
        //Метод используется только внутри класса и поэтому определен как 'закрытый' - private метод
        private OleDbCommand CreateCommand(string SQL)
        {
            if (m_Transaction == null)
                return new OleDbCommand(SQL, m_Connection);

            return new OleDbCommand(SQL, m_Connection, m_Transaction);
        }
    }

}