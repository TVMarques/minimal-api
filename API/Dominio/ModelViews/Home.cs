using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.Dominio.ModelViews
{
    public struct Home
    {
        public string Mensagem { get => "Bem vindo a API de veículos - Minimal API"; }

        public string Doc => "https://localhost:5218/swagger";//Tire o s de https no navegador, não aqui.
    }
}

//Parou no POST para criar o veículo