using Newtonsoft.Json;

// Saludo();
// TipoDatos();
// InvertirPalabra();
Vectores();
// LoadJson();
// ContarRepetidosDictionary();
// NoRepetidos();

void InvertirPalabra(){    
    Console.WriteLine($"Escriba una palabra a invertir: ");
    string? palabra = Console.ReadLine();

    if(palabra is not null){
        string palabraInvertida=""; 
        for (ushort i = (ushort)(palabra.Length-1); i>=0; i--){
           palabraInvertida += palabra[i];
           if (i==0) break;
        }

        string res = palabraInvertida.ToUpper()== palabra.ToUpper()? "Es palindromo":"No es palindromo";
        Console.WriteLine($"Palabra invertida es= {palabraInvertida}");
        Console.WriteLine($"{palabra}  {res}");
        
    }
}

void TipoDatos(){
    ushort minUshort = ushort.MinValue;
    ushort maxUshort = ushort.MaxValue;
    short minShort = short.MinValue;
    short maxShort = short.MaxValue;
    ulong minUlong = ulong.MinValue;
    ulong maxUlong = ulong.MaxValue;
    long minLong = long.MinValue;
    long maxLong = long.MaxValue;
    Console.WriteLine("---------TAMAÑO DE TIPOS DE DATOS---------");
    Console.WriteLine($"Rango ushort: {minUshort} a {maxUshort}");
    Console.WriteLine($"Rango short: {minShort} a {maxShort}");
    Console.WriteLine("------------------------------------------");
    Console.WriteLine($"Rango ulong: {minUlong} a {maxUlong}");
    Console.WriteLine($"Rango long: {minLong} a {maxLong}");
}

void Saludo(string nombre){
    string apellido = "Estan";
    Console.WriteLine($"Saludo desde metodo soy {nombre} {apellido}");
}

//aun me estoy poniendo al dia con la clase del miercoles a la que no pude asistir, voy por 1:33:36 del video
void Vectores(){
    ushort size=5;
    var vocales = new char[]{'a','e','i','o','u'};
    var consonantes = new char[]{'b','c','d','f','g','h','j','k','l','m','p','q','r','s','t','v','w','x','y','z'};
    var digitos = new int[]{0,1,2,3,4,5,6,7,8,9};    
    var alfabeto = vocales.Union(consonantes).ToArray();
    string res = "";
    for(ushort i=0; i<size; i++){
        bool letra = new Random().Next(0,100) <=50? true:false;
        if(letra){
            int k = new Random().Next(0, alfabeto.Length-1);
            bool minMayus = new Random().Next(0,100) <= 50 ? true:false;
            res += minMayus? alfabeto[k]:alfabeto[k].ToString().ToUpper();
        }else{
            int n = new Random().Next(0, 9);
            res += digitos[n].ToString();
        }
    } 
    System.Console.WriteLine("El String Aleatorio es {0}", res);

    ArrayList caracteres = new ArrayList();
    caracteres.Add(size);
    caracteres.Add(vocales);
    caracteres.Add(consonantes);
    caracteres.Add(alfabeto);
    caracteres.Add(digitos);

    foreach(var item in caracteres){
        System.Console.WriteLine($"Valor {item} ");
    }

}


//RETO: contar cuantas veces se repite la palabra - Resultado hecho en los 5 min: los cuenta pero los repite al mostrarlos
void ContarRepetidosConArreglos(){
    string[] palabras = { "Hola", "Casa", "Hola", "Perro", "Casa", "Hola", "Casa", "Hola", "Gato", "Perro" };
    string palabra ="";

    for(int i=0; i<palabras.Length-1; i++ ){        
        int count =0;
        palabra=palabras[i];
        for(int j=0; j<palabras.Length-1; j++){
            if(palabra == palabras[j]){
                count++;
            }           
        }
         System.Console.WriteLine($"La palabra {palabra} está {count} veces");
    }
}

void NoRepetidos(){
string[] palabras = { "Hola", "Casa", "Hola", "Perro", "Casa", "Hola", "Casa", "Hola", "Gato", "Perro" };
var noRepetidos=palabras.ToHashSet().ToList();

foreach(var item in noRepetidos){
    System.Console.WriteLine($"{item}");
}
}

void ContarRepetidosConDiccionarios(){
    string[] palabras = { "Hola", "Casa", "Hola", "Perro", "Casa", "Hola", "Casa", "Hola", "Gato", "Perro" };
    Dictionary<string,int> dic = new Dictionary<string, int>();
    foreach (var palabra in palabras){
        if(dic.Keys.Contains(palabra))
            dic[palabra]+=1;
        else
            dic.Add(palabra,1);

    }
     foreach(var item in dic){
            System.Console.WriteLine($"{item.Key}:{item.Value}");
        }
}

void ListarEmpresas(List<Customer> datos){
    foreach (var item in datos){
        System.Console.WriteLine($"Empresa: {item.companyName}");
        System.Console.WriteLine($"Contacto: {item.contactName}");
        System.Console.WriteLine($"Direccion: {item.address}");
        System.Console.WriteLine($"Ciudad: {item.city}");
        System.Console.WriteLine($"Pais: {item.country}");
        System.Console.WriteLine("---------------------------------------");
    }
}

void LoadJson(){
    using (StreamReader r = new StreamReader("customers.json"))
    {
        string json = r.ReadToEnd();
        List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(json);
        // var resp1 = customers.Find(it => it.city == "spain");
        //var resp2 = customers.FindAll(it => it.city == "London"); 
        // var resp3 = customers.FindAll(it => it.companyName.StartsWith("P"));
        //Console.WriteLine($"Tipo de resp es: {resp.GetType()}");

        // MostrarEmpresa(resp);
        ListarEmpresas(customers);
    }
}

public class Customer{
    public string id {get;set;}
    public string companyName {get;set;}
    public string contactName {get;set;}
    public string contactTitle {get;set;}
    public string address {get;set;}
    public string city {get;set;}
    public string postalCode {get;set;}
    public string country {get;set;}
    public string phone  {get;set;}
    public string fax {get;set;}
}


