using System;
using Interdisciplinar;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/*Requerimento = Solicitação = Ticket*/


public class Requerimento{

    //CHAVE PRIMÁRIA.Identificador do requerimento.
    private int _codigoreq;
    //Identificador do professor que abriu o requerimento.
    private string _matriculapro;
    //Identificador do grupo ao qual a mudança de nota foi requerida.
    private Grupo _codigogrupo;
    //Assunto que o Requerimento aborda.
    private string _assunto;
    //Data e hora de criação do requerimento.
    private DateTime _datareq;
    //Status do ticket: aberto(0), em andamento(1) e resolvido(2).
    private int _status;
    //Categoria em que o ticket se encaixa.
    private string _categoria;

    public Requerimento(string matricula, Grupo grupo, string assunto, DateTime data, int status, string categoria)
    {
        _matriculapro = matricula;
        _codigogrupo = grupo;
        _assunto = assunto;
        _datareq = data;
        _status = status;
        _categoria = categoria;
    }
}