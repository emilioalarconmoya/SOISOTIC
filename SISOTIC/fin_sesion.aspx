<%@ Page Language="VB" AutoEventWireup="false" CodeFile="fin_sesion.aspx.vb" Inherits="fin_sesion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>BANOTIC</title>
    <link rel="apple-touch-icon" sizes="57x57" href="favicon/apple-touch-icon-57x57.png" />
    <link rel="apple-touch-icon" sizes="60x60" href="favicon/apple-touch-icon-60x60.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="favicon/apple-touch-icon-72x72.png" />
    <link rel="apple-touch-icon" sizes="76x76" href="favicon/apple-touch-icon-76x76.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="favicon/apple-touch-icon-114x114.png" />
    <link rel="apple-touch-icon" sizes="120x120" href="favicon/apple-touch-icon-120x120.png" />
    <link rel="apple-touch-icon" sizes="144x144" href="favicon/apple-touch-icon-144x144.png" />
    <link rel="apple-touch-icon" sizes="152x152" href="favicon/apple-touch-icon-152x152.png" />
    <link rel="apple-touch-icon" sizes="180x180" href="favicon/apple-touch-icon-180x180.png" />
    <link rel="icon" type="image/png" href="favicon/favicon-32x32.png" sizes="32x32" />
    <link rel="icon" type="image/png" href="favicon/android-chrome-192x192.png" sizes="192x192" />
    <link rel="icon" type="image/png" href="favicon/favicon-96x96.png" sizes="96x96" />
    <link rel="icon" type="image/png" href="favicon/favicon-16x16.png" sizes="16x16" />
    <link rel="manifest" href="favicon/manifest.json" />
    <meta name="msapplication-TileColor" content="#da532c" />
    <meta name="msapplication-TileImage" content="favicon/mstile-144x144.png" />
    <meta name="theme-color" content="#ffffff" />
    <link href="estilo.css" rel="stylesheet" type="text/css" />
     <link rel="stylesheet" type="text/css" href="estilo.css"/>
    <%--<link rel="alternate stylesheet" type="text/css" href="estilo1.css" title="estilo1">
    <link rel="alternate stylesheet" type="text/css" href="estilo2.css" title="estilo2">
    <link rel="alternate stylesheet" type="text/css" href="estilo3.css" title="estilo3">--%>
    
        <%--<script language="javascript"  type="text/javascript" >
           function setActiveStyleSheet(title) {
              var i, a, main;
              for(i=0; (a = document.getElementsByTagName("link")[i]); i++) {
                if(a.getAttribute("rel").indexOf("style") != -1 && a.getAttribute("title")) {
                  a.disabled = true;
                  if(a.getAttribute("title") == title) a.disabled = false;
                }
              }
            }

            function getActiveStyleSheet() {
              var i, a;
              for(i=0; (a = document.getElementsByTagName("link")[i]); i++) {
                if(a.getAttribute("rel").indexOf("style") != -1 && a.getAttribute("title") && !a.disabled) return a.getAttribute("title");
              }
              return null;
            }

            function getPreferredStyleSheet() {
              var i, a;
              for(i=0; (a = document.getElementsByTagName("link")[i]); i++) {
                if(a.getAttribute("rel").indexOf("style") != -1
                   && a.getAttribute("rel").indexOf("alt") == -1
                   && a.getAttribute("title")
                   ) return a.getAttribute("title");
              }
              return null;
            }

            function createCookie(name,value,days) {
              if (days) {
                var date = new Date();
                date.setTime(date.getTime()+(days*24*60*60*1000));
                var expires = "; expires="+date.toGMTString();
              }
              else expires = "";
              document.cookie = name+"="+value+expires+"; path=/";
            }

            function readCookie(name) {
              var nameEQ = name + "=";
              var ca = document.cookie.split(';');
              for(var i=0;i < ca.length;i++) {
                var c = ca[i];
                while (c.charAt(0)==' ') c = c.substring(1,c.length);
                if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
              }
              return null;
            }

            window.onload = function(e) {
              var cookie = readCookie("style");
              var title = cookie ? cookie : getPreferredStyleSheet();
              setActiveStyleSheet(title);
            }

            window.onunload = function(e) {
              var title = getActiveStyleSheet();
              createCookie("style", title, 365);
            }

            var cookie = readCookie("style");
            var title = cookie ? cookie : getPreferredStyleSheet();
            setActiveStyleSheet(title);
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div id="FinSesion">
        <%--<table style="width: 980px; position: static" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center">
                    <span style="font-size: 11pt"><strong>La sesión en CONSOLA DE GESTION ha finalizado, </strong>sírvase ingresar nuevamente sus datos de identificación si desea reingresar.<br />
                        <br />
                        Algunas veces las sesiones finalizan por un tiempo de inactividad prolongado, esto
                        es por seguridad.</span></td>
            </tr>
            <tr>
                <td align="center">
                    <span style="font-size: 11pt">
                        <br />
                        <a href="login.aspx">Ingrese Nuevamente Aquí</a></span></td>
            </tr>
        </table>--%>
        <div id="texto">
            <span><strong>La sesión en SisOtic ha finalizado,
            </strong>sírvase ingresar nuevamente sus datos de identificación si desea reingresar.<br />
            <br />Algunas veces las sesiones finalizan por un tiempo de inactividad prolongado, esto es por seguridad.</span>        
        </div>
        <div id="link">
            <a href="login.aspx">Ingrese Nuevamente Aquí</a>        
        </div>        
    </div>
    </form>
</body>
</html>
