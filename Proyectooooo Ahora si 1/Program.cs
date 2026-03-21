int opcion = 0;
string tipo = "";
int duracion = 0;
string clasificacion = "";
int hora = 0;
string produccion = "";
string razon = "";
int totalevaluados = 0;
int rechazados = 0;
string impacto = "Bajo";
int impactoalto = 0;
int impactomedio = 0;
int impactobajo = 0;
int revision = 0;
int publicados = 0;
double porcentaje = 0;
string impactopredominante = "bajo";

do
{
    Console.WriteLine("-------STREAMING-------");
    Console.WriteLine("Opcion 1 (Evaluacion de contenido): ");
    Console.WriteLine("Opcion 2 (Mostrar reglas del sistema): ");
    Console.WriteLine("Opcion 3 (Mostrar Estadistica): ");
    Console.WriteLine("Opcion 4 (Reiniciar Estadisticas): ");
    Console.WriteLine("Opcion 5 (Salir): ");
    opcion = Convert.ToInt32(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            {
                Console.Clear();
                evaluar();
            }
            break;
        case 2:
            {
                Console.Clear();
                mostrar();
            }
            break;
        case 3:
            {
                Console.Clear();
                Estadisticas();
            }
            break;
        case 4:
            {
                Console.Clear();
                Reiniciar();
            }
            break;
        case 5:
            {
                Console.Clear();
                Console.WriteLine("Saliendo...");
            }
            break;
        default:
            {
                Console.Clear();
                Console.WriteLine("Esta opcion no es valida.");
            }
            break;
    }


} while (opcion != 5);

void evaluar()
{
    Console.Clear();
    Console.WriteLine("Tipo (pelicula/serie/documental/evento): ");
    tipo = Console.ReadLine().ToLower();
    Console.WriteLine("Duracion en minutos: ");
    duracion = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Clasificacion (Todo publico/+13/+18): ");
    clasificacion = Console.ReadLine().ToLower();
    Console.WriteLine("Hora programada (0-23): ");
    hora = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Produccion (Alta/media/baja): ");
    produccion = Console.ReadLine().ToLower();

    bool valido = true;

    if (tipo == "pelicula")
    {
        if (duracion < 60 || duracion > 180)
        {
            valido = false;
            razon = "La duracion que ingreso no es valida para la pelicula.";
        }
    }
    else if (tipo == "serie")
    {
        if (duracion < 30 || duracion > 120)
        {
            if (duracion < 20 || duracion > 90)
            {
                valido = false;
                razon = "La duracion que ingreso no es valida para la serie";
            }
        }
    }
    else if (tipo == "evento")
    {
        if (duracion < 30 || duracion > 240)
        {
            valido = false;
            razon = "La duracion que ingreso no es valida para evento";
        }
    }
    if (valido)
    {
        if (clasificacion == "+13")
        {
            if (hora < 6 || hora > 22)
            {
                valido = false;
                razon = "Este horario no es permitido para +13";
            }
        }
    }
    else if (clasificacion == "+18")
    {
        if (!(hora >= 22 || hora <= 5))
        {
            valido = false;
            razon = "Este horario no es permitido para +18";
        }
    }
    if (valido)
    {
        if (produccion == "bajo")
        {
            if (clasificacion == "+18")
            {
                valido = false;
                razon = " Produccion baja no es permitida para +18";
            }
        }
    }
    totalevaluados++;
    if (!valido)
    {
        Console.WriteLine("Desicion: Rechazar");
        Console.WriteLine("Razon: " + razon);
        rechazados++;
        return;
    }

    if (produccion == "Alto" || duracion > 120 || (hora >= 20 && hora <= 23))
    {
        impacto = "Alto";
        impactoalto++;
    }
    else if (produccion == "medio" || (duracion >= 60 && duracion <= 120))
    {
        impacto = "medio";
        impactomedio++;

    }
    else
    {
        impacto = "Bajo";
        impactobajo++;
    }
    if (impacto == "Alto")
    {
        Console.WriteLine("Desicion: Enviar a resultados");
        revision++;
    }
    else
    {
        Console.WriteLine("Desicion: Publicar");
        publicados++;
    }
    Console.WriteLine("Impacto: " + impacto);
}

void mostrar()
{
    Console.Clear();
    Console.WriteLine("--------Reglas---------");
    Console.WriteLine("Peliculas 60 - 180");
    Console.WriteLine("Serie 20 - 90");
    Console.WriteLine("Documental 30 - 120");
    Console.WriteLine("Evento 30 - 240");

    Console.WriteLine("--------Clasificacion--------");
    Console.WriteLine("Todo publico: Cualquier hora");
    Console.WriteLine("+13: 6 - 22");
    Console.WriteLine("+18: 22 - 5");

    Console.WriteLine("Produccion Baja solo Todo publico o +13");
}

void Estadisticas()
{
    Console.Clear();
    Console.WriteLine("Total evaluados: " + totalevaluados);
    Console.WriteLine("Publicados: " + publicados);
    Console.WriteLine("Rechazados: " + rechazados);
    Console.WriteLine("En revision: " + revision);

    int aprobados = publicados + revision;

    if (totalevaluados > 0)
    {
        porcentaje = (aprobados * 100) / totalevaluados;
        Console.WriteLine("Porcentaje de aprobacion: " + porcentaje + "%");
    }


    if (impactoalto > impactomedio && impactoalto > impactobajo)
    {
        impactopredominante = "Alto";
    }
    else if (impactomedio > impactobajo)
    {
        impactopredominante = "Medio";
    }

    Console.WriteLine("Impacto Predominante: " + impactopredominante);
}

void Reiniciar()
{
    totalevaluados = 0;
    publicados = 0;
    rechazados = 0;
    revision = 0;
    impactoalto = 0;
    impactomedio = 0;
    impactobajo = 0;

    Console.WriteLine("Las Estadisticas se han reiniciado.");
}
