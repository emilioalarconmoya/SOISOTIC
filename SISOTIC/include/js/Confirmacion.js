function ConfirmarEnvio(control,texto)
            {
                var envio = document.getElementById(control)
                    if (envio.value == 1)
                    {
                        alert('Los datos ya han sido enviados.\nPor favor esperar un momento.');
                        return false;
                    }
                if(confirm(texto)) 
                {                    
                    document.getElementById(control).value = 1;
                }
                else
                {                    
                    document.getElementById(control).value = 0;
                    return false;
                }
            }