//  Esta Función Verifica que el rut que el usuario ingresó tiene el formato correcto.

//Acá puede ser vacío
function VerificarRutSiVacio(source, arguments){
        var rut = arguments.Value;
        if(isEmpty(source)){
            source.IsValid = true;
            return true;
        }
        VerificarRut(source,arguments);
}

function VerificarRut(source, arguments)
	{
	    var rut = arguments.Value;
		var DV="";
		var DVaux="";
		var DI;
		var suma=0;
		var largo;
		var mult=2;
		var rut1;
		var texto = rut;
		var tmpstr = "";
		for ( i=0; i < texto.length ; i++ )
			if ( texto.charAt(i) != ' ' && texto.charAt(i) != '.' && texto.charAt(i) != '-' )
		tmpstr = tmpstr + texto.charAt(i);
		texto = tmpstr;
		rut = texto;
		if (rut.charAt(rut.length-2) == '-')
			largo=rut.length-2;
		else largo = rut.length-1;

		rut1 = texto.substr(0,texto.length-1);
		//if ((rut.length <= 1) || (isNaN(rut1)))
		//{
		//	arguments.IsValid = false;
		//	return false;
		//}
		if ((rut.length < 1) || (isNaN(rut1)))//= 5) || (isNaN(rut1)))
		{
//			alert("Debe completar correctamente el campo Rut.");
//			C_Rut.value = "";
//			C_Rut.select();
//			C_Rut.focus();
			arguments.IsValid = false;
			return true;
		}
		if ( rut.charAt(rut.length-1) !="0" && rut.charAt(rut.length-1) != "1" && rut.charAt(rut.length-1) !="2" && rut.charAt(rut.length-1) != "3" && rut.charAt(rut.length-1) != "4" && rut.charAt(rut.length-1) !="5" && rut.charAt(rut.length-1) != "6" && rut.charAt(rut.length-1) != "7" && rut.charAt(rut.length-1) !="8" && rut.charAt(rut.length-1) != "9" && rut.charAt(rut.length-1) !="k" && rut.charAt(rut.length-1) != "K" )
		{
			arguments.IsValid = false;
			return false;
		}

	   	for(i=0;i<largo;i++)
	   	{
	   		if(mult==8) mult=2;
      		suma = suma + parseInt(rut.substring(largo-i-1,largo-i))*mult;
	      	mult++;
	   	}

  		DI= 11 + 11*(parseInt(suma/11)) - suma;
   		if(DI!=10) DV=DV+DI;
   		if(DI==10)
   		{
			DV="K";
			DVaux="k";
		}
	   	if(DI==11) DV="0";
	   	if( (rut.charAt(rut.length-1) != DV) && (rut.charAt(rut.length-1) != DVaux) )
		{
	        arguments.IsValid = false;
			return false;
		}
		// desde aqui

		var invertido = "";
		for ( i=(largo),j=0; i>=0; i--,j++ )
		    invertido = invertido + texto.charAt(i);

		var dtexto = "";
		dtexto = dtexto + invertido.charAt(0);
		dtexto = dtexto + '-';
		cnt = 0;
		for ( i=1,j=2; i<largo+1; i++,j++ )
		{
			if ( cnt == 3 )
			{
			   dtexto = dtexto + '.';
			   j++;
			   cnt = 1;
			}
		    else cnt++;
		    dtexto = dtexto + invertido.charAt(i);
		}
		invertido = "";
		for ( i=(dtexto.length-1),j=0; i>=0; i--,j++ )
		    invertido = invertido + dtexto.charAt(i);
		    
		arguments.Value = invertido.Value;
		arguments.IsValid = true;
		return true;
	}
	
// funcion: EsNumero
// Descripcion: Recibe el parametro "valor" que es una referencia a un campo de texto
// Valida además, que no esté vacío
  function EsNumeroNoVacio(source, arguments) {  //Funcion para verificar si un campo es un numero
    var valor = arguments;
    var espacio = /^[\s]+$/;	//Variable que verifica si lo ingresado por el usuario es un espacio
    var dato = valor.Value; //Asignamos a "dato" el valor ingresado por el usuario
    var aux = (parseInt(dato,10) == dato);	
	if ( (isNaN(dato)) || (espacio.test(dato)) || (!aux) ){ //Se verifica que "dato" sea un numero.
        arguments.IsValid = false;
        return false;   //retorna falso si es no es un numero
    }
    if ( (dato != "") && (!(isNaN(dato))) ){  //Si dato no es vacio y es un numero          
        arguments.IsValid = true;  
	    return true;  //retorna verdadero
    }   
  }

  
// s es vacio
function isEmpty(s)
{   return ((s == null) || (s.length == 0))
}

// c es un digito
function isDigit (c)
{   return ((c >= "0") && (c <= "9"))
}

  
  function isNumber (s)
{   var i;
    var dotAppeared;
    dotAppeared = false;
    if (isEmpty(s)) 
       if (isNumber.arguments.length == 1) return true;
       else return (isNumber.arguments[1] == true);
    
    for (i = 0; i < s.length; i++)
    {   
        var c = s.charAt(i);
        if( i != 0 ) {
            if ( c == "." ) {
                if( !dotAppeared )
                    dotAppeared = true;
                else
                    return false;
            } else     
                if (!isDigit(c)) return false;
        } else { 
            if ( c == "." ) {
                if( !dotAppeared )
                    dotAppeared = true;
                else
                    return false;
            } else     
                if (!isDigit(c) && (c != "-") || (c == "+")) return false;
        }
    }
    return true;
}

function esFechaValida(source, arguments){
	if (fecha != undefined && fecha.value != "" ){
		if (!/^\d{2}\/\d{2}\/\d{4}$/.test(fecha.value)){
			alert("formato de fecha no válido (dd/mm/aaaa)");
			return false;
		}
		var dia  =  parseInt(fecha.value.substring(0,2),10);
		var mes  =  parseInt(fecha.value.substring(3,5),10);
		var anio =  parseInt(fecha.value.substring(6),10);
	switch(mes){
		case 1:
		case 3:
		case 5:
		case 7:
		case 8:
		case 10:
		case 12:
			numDias=31;
			break;
		case 4: case 6: case 9: case 11:
			numDias=30;
			break;
		case 2:
			if (comprobarSiBisisesto(anio)){ numDias=29 }else{ numDias=28};
			break;
		default:
			alert("Fecha introducida errónea");
			return false;
	}
		if (dia>numDias || dia==0){
			alert("Fecha introducida errónea");
			return false;
		}
		return true;
	}
}
function comprobarSiBisisesto(anio){
if ( ( anio % 100 != 0) && ((anio % 4 == 0) || (anio % 400 == 0))) {
	return true;
	}
else {
	return false;
	}
}

function confirma(strTexto)
{
   if(Page_ClientValidate())
      return confirm(strTexto);

   return false;
}
