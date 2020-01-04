Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Application description"

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Contact."

        Return View()
    End Function
End Class
