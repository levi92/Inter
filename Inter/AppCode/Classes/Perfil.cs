/*
    SE VOCÊ QUER APRENDER SOBRE RECURSIVIDADE, VÁ PARA O FIM DA PÁGINA...
*/

public class Perfil
{
    private string per_matricula;
    private int per_descricao;
    private string per_login;
    private string per_senha;
    private string per_usuario;

    public string Matricula
    {
        get { return per_matricula; }
        set { per_matricula = value; }
    }

    public int Descricao
    {
        get { return per_descricao; }
        set { per_descricao = value; }
    }

    public string Login
    {
        get { return per_login; }
        set { per_login = value; }
    }

    public string Senha
    {
        get { return per_senha; }
        set { per_senha = value; }
    }

    public string Per_usuario
    {
        get { return per_usuario; }
        set { per_usuario = value; }
    }

    public Perfil(string acesso)
    {
        if (acesso == "master")
        {
            per_matricula = "adm_master";
        }
        else if (acesso == "coord")
        {
            
        }
    }

    public Perfil()
    {

    }

}

/*
    SE VOCÊ QUER APRENDER SOBRE RECURSIVIDADE, VÁ PARA O TOPO DA PÁGINA...
*/