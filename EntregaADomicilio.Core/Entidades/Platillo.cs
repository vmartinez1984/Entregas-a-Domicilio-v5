﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EntregaADomicilio.Core.Entidades
{
    public class Platillo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public int Id { get; set; }


        public string Categoria { get; set; }


        public string Nombre { get; set; }


        public string Descripcion { get; set; }


        public double Precio { get; set; }


        public bool EstaActivo { get; set; } = true;

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

        public string EncodedKey { get; set; }

        public Archivo Archivo { get; set; }
    }

    public class Archivo
    {
        public string RutaDelArchivo { get; set; }              
                
        public string NombreDelArchivo { get; set; }
                
        public string ContentType { get; set; }               
              
        public string AliasDelArchivo { get; set; }

        public DateTime FechaDeRegistro { get; set; }
    }
}