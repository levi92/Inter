using System;
using Interdisciplinar;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/*Requerimento = Solicitação = Ticket*/


public class Requerimento{

    //CHAVE PRIMÁRIA.Identificador do requerimento.
    public int CodigoReq { get; set;  }
    //Identificador do professor que abriu o requerimento.
    public string MatriculaPro { get; set; }
    //Identificador do grupo ao qual a mudança de nota foi requerida.
    public int CodigoGrupo { get; set; }
    //Assunto que o Requerimento aborda.
    public string Assunto { get; set; }
    //Data e hora de criação do requerimento.
    public DateTime DataReq { get; set; }
    //Status do ticket: aberto(0), em andamento(1) e resolvido(2).
    public int Status { get; set; }
    //Categoria em que o ticket se encaixa.
    public string Categoria { get; set; }

    public Requerimento(string matricula, int grupo, string assunto, DateTime data, int status, string categoria)
    {
        MatriculaPro = matricula;
        CodigoGrupo = grupo;
        Assunto = assunto;
        DataReq = data;
        Status = status;
        Categoria = categoria;
    }
    //Constructor do select
    public Requerimento(int codigo, string matricula, int grupo, string assunto, DateTime data, int status, string categoria)
    {
        CodigoReq = codigo;
        MatriculaPro = matricula;
        CodigoGrupo = grupo;
        Assunto = assunto;
        DataReq = data;
        Status = status;
        Categoria = categoria;
    }
    //Constructor do Insert
    public Requerimento(string matricula, int grupo, string assunto, string categoria)
    {
        MatriculaPro = matricula;
        CodigoGrupo = grupo;
        Assunto = assunto;
        Categoria = categoria;
        DataReq = DateTime.Now; //Pega na hora da criação o tempo do servidor
        Status = 0; //Por padrão: Status "em aberto"
    }
}