use Encode qw(encode decode);
use utf8;
use DB_File;
use MLDBM "DB_File";
my (%english, %russian, %hash);
tie %hash, MLDBM, "title.db" or die "$!";

$english{'ABOUT_PROGRAM'} = "About program";
$english{'ERROR'} = "Error!";
$english{'HELP'} = "Help";
$english{'EXIT'} = "Exit";
$english{'FILE_MENU'} = "File";
$english{'MAIN_WINDOW_TITLE'} = "Crossword";
$english{'BUTTON_CANCEL'} = "Cancel"; 
$english{'BUTTON_CLEAR'} = "Clear";
$english{'BUTTON_FILL'} = "Fill the crossword";
$english{'ERROR_OPENING_FILE'} = "Error opening file $ filename!";
$english{'MESSAGE_ABOUT_PROGRAM'} =  <<text;
version 1.0
© Telyatnikova Mary, 2013. All rights reserved.

The "crossword generator" developed by Maria Telyatnikova.
text
$english{'EMPTY_WORDS_LIST_ERROR'} = "Does not contain a words list!";
$english{'UNDEFINED_GEOMETRY_ERROR'} = "No geometry is given a crossword puzzle!";
$english{'RADIOBUTTON_SET_FILE'} = "Set the file\n with words";
$english{'RADIOBUTTON_ENTER_WORDS'} = "Enter the words";
$english{'BUTTON_SAVE_WORDS'} = "Save the words";
$english{'BUTTON_SET_GEOMETRY'} = "Set the crossword\ngeometry";
$english{'SIZE'} = "Size crossword";
$english{'ROWS'} = "Rows";
$english{'COLUMNS'} = "Columns";
$english{'CROSSWORD_GEOMETRY'} = "Crossword geometry";
$english{'BUTTON_SAVE_WORD'} = "Save the word";
$english{'BUTTON_SAVE_GEOMETRY'} = "Save geometry";
$english{'ERROR_ENTERING_COORDINATES'} = "You have incorrectly entered the coordinates of the word!";
$english{'SAVE'} = "Save";
$english{'SAVE_CROSSWORD'} = "Save the crossword?";
$english{'NAME'} = "The name of the crossword";
$english{'YES'} = "Yes";
$english{'NO'} = "No";
$english{'EXISTING_NAME'} = "This name already exists. Enter another.";
$english{'SAVED_CROSSWORDS'} = "Saved crosswords";
$english{'POD'} = "Plain Old Documentation";
$english{'FAILURE_MESSAGE'} = "It is impossible to fill the crossword";
$english{'BUTTON_SET_WORDS'} = "Set words";
$english{'BUTTON_LOAD_FILE'} = "Load file";
$english{'LANGUAGE'} = "Language";
$english{'BUTTON_CHANGE_SIZE'} = "Change size";
$hash{"English"} = \%english;

$russian{'ABOUT_PROGRAM'} = "О программе";
$russian{'ERROR'} = "Ошибка!";
$russian{'HELP'} = "Справка";
$russian{'EXIT'} = "Выход";
$russian{'FILE_MENU'} = "Файл";
$russian{'MAIN_WINDOW_TITLE'} = "Кроссворд";
$russian{'BUTTON_CANCEL'} = "Отменить"; 
$russian{'BUTTON_CLEAR'} = "Очистить";
$russian{'BUTTON_FILL'} = "Заполнить кроссворд";
$russian{'ERROR_OPENING_FILE'} = "Ошибка при открытии файла $filename!";
$russian{'MESSAGE_ABOUT_PROGRAM'} =  <<text;
Версия 1.0
© Телятникова Мария,2013.Все права защищены.

Программа "Генератор кроссвордов" разработана Марией Телятниковой.
text
$russian{'EMPTY_WORDS_LIST_ERROR'} = "Не задан список слов!";
$russian{'UNDEFINED_GEOMETRY_ERROR'} = "Не задана геометрия кроссворда!";
$russian{'RADIOBUTTON_SET_FILE'} = "Задать файл\nсо словами";
$russian{'RADIOBUTTON_ENTER_WORDS'} = "Ввести слова";
$russian{'BUTTON_SAVE_WORDS'} = "Сохранить слова";
$russian{'BUTTON_SET_GEOMETRY'} = "Задать геометрию\nкроссворда";
$russian{'SIZE'} = "Размер кроссворда";
$russian{'ROWS'} = "Строк";
$russian{'COLUMNS'} = "Столбцов";
$russian{'CROSSWORD_GEOMETRY'} = "Геометрия кроссворда";
$russian{'BUTTON_SAVE_WORD'} = "Запомнить слово";
$russian{'BUTTON_SAVE_GEOMETRY'} = "Сохранить геометрию";
$russian{'ERROR_ENTERING_COORDINATES'} = "Вы неправильно ввели координаты слова!";
$russian{'SAVE'} = "Сохранить";
$russian{'SAVE_CROSSWORD'} = "Сохранить кроссворд?";
$russian{'NAME'} = "Название кроссворда";
$russian{'YES'} = "Да";
$russian{'NO'} = "Нет";
$russian{'EXISTING_NAME'} = "Такое название уже существует.Введите другое.";
$russian{'SAVED_CROSSWORDS'} = "Сохранённые кроссворды";
$russian{'POD'} = "Простая старая документация";
$russian{'FAILURE_MESSAGE'} = "Невозможно заполнить кроссворд!";
$russian{'BUTTON_SET_WORDS'} = "Установить слова";
$russian{'BUTTON_LOAD_FILE'} = "Загрузить файл";
$russian{'LANGUAGE'} = "Язык";
$russian{'BUTTON_CHANGE_SIZE'} = "Изменить размер";
$hash{'Russian'} = \%russian;
untie %hash;