using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCode;


public class Ticket
{
    //Métodos estão privados porque o set e get estão inline
    public int Tic_Id { get; private set; } //CHAVE PRIMÁRIA.Identificador do Ticket. Set privado pois é autoincrementado no BD
    public string Tic_Id_Professor { get; set; } // Identificador do professor que CRIOU o ticket (Usuário que criou)
    public int Tic_Estado { get; set; } //Estado do Ticket: Não Aberto(0 - vermelho fatec), aberto(1 - azul), encerrado favorável(2 - verde), encerrado não favorável(3 - amarelo) 
    public int Tic_Prioridade { get; set; } //Prioridade Normal (0 - padrão - ícone verde), média (1 - ícone amarelo), alta (2 - ícone vermelho)
    public string Tic_Assunto { get; set; } //Assunto do ticket
    public string Tic_Tipo { get; set; } //Tipo do Ticket. Categorias pré-definidas. (Usuário)
    public DateTime Tic_Data { get; set; } //Data e hora da criação do Ticket

    private string tic_usuario;

    public string Tic_usuario
    {
        get { return tic_usuario; }
        set { tic_usuario = value; }
    }
}