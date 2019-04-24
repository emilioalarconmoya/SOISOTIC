//
//Funcion: AbrirVentana
//Descripcion: Abre una ventana con la URL indicada, sin barras de navegacion
//
function popup(URL, Titulo, alto, ancho)  {

  //Define el tamaño de la ventana
  var window_height = alto;
  var window_width  = ancho;

  //Calcula posicion
  var window_top  = ( screen.availHeight  - window_height  ) / 2
  var window_left = ( screen.availWidth  - window_width  ) / 2
  
  //Construye string con propiedades de ventana a abrir
  var window_prop = "";
  window_prop += "status=no,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=yes" + ",";
  window_prop += "HEIGHT=" + window_height + ",";
  window_prop += "WIDTH="  + window_width  + ",";
  window_prop += "top="  + ( ( window_top  > 0 ) ? window_top  : 0 ) + ",";
  window_prop += "left="   + ( ( window_left > 0 ) ? window_left : 0 );
  window_prop += ",dependent=yes";

  //Abre ventana
  var msg = window.open(URL, Titulo, window_prop);

  //Retorna
  return(msg);
}
function popup_pos(URL, Titulo, alto, ancho, posx, posy)  {

  //Define el tamaño de la ventana
  var window_height = alto;
  var window_width  = ancho;

  //Calcula posicion
  var window_top  = posy;
  var window_left = posx;
  
  //Construye string con propiedades de ventana a abrir
  var window_prop = "";
  window_prop += "status=no,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=yes" + ",";
  window_prop += "HEIGHT=" + window_height + ",";
  window_prop += "WIDTH="  + window_width  + ",";
  window_prop += "top="  + ( ( window_top  > 0 ) ? window_top  : 0 ) + ",";
  window_prop += "left="   + ( ( window_left > 0 ) ? window_left : 0 );
  window_prop += ",dependent=yes";

  //Abre ventana
  var msg = window.open(URL, Titulo, window_prop);

  //Retorna
  return(msg);
}