<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%var date = (DateTime)Model; %>
<%=Html.h(date.ToShortDateString()) %>
