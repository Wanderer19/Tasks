﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Домашняя страница — приложение ASP.NET MVC
</asp:Content>

<asp:Content ID="indexFeatured" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Домашняя страница.</h1>
                <h2><%: ViewBag.Message %></h2>
            </hgroup>
            <p>
                Для получения дополнительных сведений о ASP.NET MVC посетите веб-сайт 
                <a href="http://asp.net/mvc" title="ASP.NET MVC Website">http://asp.net/mvc</a>.
                На странице представлены <mark>видеоматериалы, учебники и образцы кода</mark> , позволяющие лучшим образом использовать ASP.NET MVC.
                По всем вопросам об ASP.NET MVC обращайтесь на
                <a href="http://forums.asp.net/1146.aspx/1?MVC" title="ASP.NET MVC Forum">наши форумы</a>.
            </p>
        </div>
    </section>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Рекомендуются следующие действия:</h3>
    <ol class="round">
        <li class="one">
            <h5>Приступая к работе</h5>
            ASP.NET MVC — это мощная платформа на основе шаблонов, позволяющая создавать динамические веб-сайты с
            разделением сфер ответственности и полным контролем над разметкой:
            разработка будет быстрой и удобной. ASP.NET MVC включает много функций,
            обеспечивающих скорость и эффективность разработки на основе тестов, что дает возможность создавать сложные приложения, использующие
            новейшие веб-стандарты.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245151">Дополнительные сведения...</a>
        </li>

        <li class="two">
            <h5>Добавление пакетов NuGet и переход к программированию</h5>
            NuGet упрощает установку и обновление бесплатных библиотек и средств.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245153">Дополнительные сведения…</a>
        </li>

        <li class="three">
            <h5>Найти поставщика услуг размещения веб-сайтов</h5>
            Можно легко найти компанию, предоставляющую услуги размещения приложений в Интернете и отвечающую вашим требованиям
            к цене и функциональным возможностям.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245157">Дополнительные сведения…</a>
        </li>
    </ol>
</asp:Content>
