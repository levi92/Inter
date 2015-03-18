<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Usuario/MasterPageMenuPadrao.master" AutoEventWireup="true" Inherits="paginas_Usuario_consultarPi" Codebehind="consultarPi.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudoCentral" runat="Server">

    <!-- ALTERAR COR DO ÍCONE NO MENU LATERAL -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#cphConteudo_icone6').addClass('corIcone');
        });
    </script>

    <!-- Consultar PI (p6) -->

    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Consultar PI</h3>
            </div>

            <div class="panel-body-usuarios">
                <table class="table">

                    <tr>
                        <td>
                            <asp:Label ID="Label1" CssClass="label" runat="server" Text="Código PI: "></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label2" runat="server" Text="01"></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label3" CssClass="label" runat="server" Text="Curso: "></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label4" runat="server" Text="ADS"></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label5" CssClass="label" runat="server" Text="Semestre: "></asp:Label>                            
                        </td>

                        <td>
                            <asp:Label ID="Label6" runat="server" Text="4"></asp:Label>

                        </td>


                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label7" CssClass="label" runat="server" Text="Ano: "></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label8" runat="server" Text="2014 "></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label9" CssClass="label" runat="server" Text="Semestre Ano: "></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="02"></asp:Label>
                        </td>


                        <td colspan="2"></td>
                    </tr>

                </table>



                <table style="text-align: justify; width: 60%;">
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h4>Datas de Eventos:</h4>
                        </td>
                        <td></td>

                    </tr>

                    <tr>
                        <td>Prévia 1 - 12/10/2014
                                        <br />
                            Prévia 2 - 12/11/2014
                                        <br />
                            Apresentação Final - 12/12/2014 
                                        <br />
                        </td>

                        <td>
                            <button type="button" class="btn btn-default" id="btnEditar" onclick="Mostra('p5');">
                                <span class="glyphicon glyphicon-pencil"></span>&nbsp Editar Datas
                            </button>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            <br />
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <h4>Disciplinas envolvidas:</h4>
                        </td>
                        <td colspan="2"></td>
                    </tr>

                    <tr>
                        <td>Banco de Dados
                                        <br />
                            Engenharia de Software 3
                                        <br />
                            Interação Humano-Computador
                                        <br />
                            Programação em Scripts
                                        <br />
                        </td>
                        <td></td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>

                </table>

                <!-- Editar Critério-->
                <table style="text-align: justify; width: 60%;">
                    <tr>
                        <td>
                            <h4>Critérios</h4>
                        </td>
                        <td>
                            <h4>Pesos</h4>
                        </td>
                        <td></td>
                    </tr>

                    <tr>
                        <td>Postura<br />
                            Vestimenta<br />
                            Fala<br />
                            Sistema<br />
                            Conhecimento<br />
                        </td>

                        <td>2<br />
                            3<br />
                            3<br />
                            1<br />
                            1<br />
                        </td>

                        <td>
                            <button type="button" class="btn btn-default" id="btnCriterio" onclick="Mostra('p10');">
                                <span class="glyphicon glyphicon-pencil"></span>&nbsp Editar Critérios
                            </button>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3">
                            <hr />
                        </td>
                    </tr>
                </table>

                <table style="text-align: justify; width: 100%;">
                    <tr>
                        <td colspan="4">
                            <h4>Grupos</h4>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <label>Inter - Adiministrador</label></td>
                        <td>
                            <label>Inter - Usuário</label></td>
                        <td>
                            <label>Sam - Adiministrador</label></td>
                        <td>
                            <label>Sam - Usuário</label></td>
                    </tr>

                    <tr>
                        <td style="width: 20%;">
                            <div style="width: 80%; border: 1px solid gray; padding-left: 10px; border-radius: 5px">
                                Aluno1<br />
                                Aluno2<br />
                                Aluno3<br />
                                Aluno4<br />
                                Aluno5<br />
                            </div>
                        </td>

                        <td style="width: 20%;">
                            <div style="width: 80%; border: 1px solid gray; padding-left: 10px; border-radius: 5px">
                                Aluno1<br />
                                Aluno2<br />
                                Aluno3<br />
                                Aluno4<br />
                                Aluno5<br />
                            </div>
                        </td>

                        <td style="width: 20%;">
                            <div style="width: 80%; border: 1px solid gray; padding-left: 10px; border-radius: 5px">
                                Aluno1<br />
                                Aluno2<br />
                                Aluno3<br />
                                Aluno4<br />
                                Aluno5<br />
                            </div>
                        </td>
                        <td style="width: 20%;">
                            <div style="width: 80%; border: 1px solid gray; padding-left: 10px; border-radius: 5px">
                                Aluno1<br />
                                Aluno2<br />
                                Aluno3<br />
                                Aluno4<br />
                                Aluno5<br />
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="4" style="padding-left: 10px;">
                            <br />
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3"></td>
                        <td>
                            <button type="button" class="btn btn-default" id="btnGrupo" onclick="Mostra('p13');">
                                <span class="glyphicon glyphicon-pencil"></span>&nbsp Editar Grupos
                            </button>
                        </td>
                    </tr>
                </table>

            </div>
        </div>
    </div>

</asp:Content>

