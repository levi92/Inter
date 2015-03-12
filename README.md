# ![](https://github.com/levi92/Inter./blob/master/App_Themes/images/logoTopo.png?raw=true)

Inter. Ã© um sistema de gerenciamento de trabalhos interdisciplinares que estÃ¡ sendo desenvolvido como Trabalho de ConclusÃ£o de Curso dos alunos de AnÃ¡lise e Desenvolvimento de Sistemas da Fatec GuaratinguetÃ¡, turma 2015.

### PrÃ©-requisitos

Antes de comeÃ§ar a usar o GitHub com o Visual Studio confira se as depÃªndencias do mesmo estÃ£o instaladas:

* [MysysGit](https://msysgit.github.io/)
* [Git Tools For Visual Studio](https://visualstudiogallery.msdn.microsoft.com/abafc7d6-dcaa-40f4-8a5e-d6724bdb980c) (somente para Visual Studio 2012 ou inferior)
* [GitHub Client for Windows]() (opcional)

### Configurando o visual Studio

1. Abra o **Team Explorer**
2. Clique na aba **Connect**
3. Clique em **Clone**
4. O **endereÃ§o** do projeto Ã© **[https://github.com/levi92/Inter.](https://github.com/levi92/Inter.)**
5. Insira seu **Username** e **Password** do GitHub
6. **Pronto**, o repositÃ³rio estÃ¡ clonado localmente e pronto para **trabalhar**

### Usando o GitHub 

#### Estrutura do GitHub

O GitHub Ã© um controle de versÃ£o que trabalha localmente, o oposto de outras soluÃ§Ãµes com servidores centralizados como o Subversion e o TFS. Nesse sistema o servidor central contÃ©m o cÃ³digo sendo desenvolvido porÃ©m cada usuÃ¡rio clona esse repositÃ³rio para sua mÃ¡quina local e trabalha de maneira totalmente *offline*, sem a necessidade de mais *checks* com o servidor central. Estando pronto seu desenvolvimento basta realizar um *push* para o servidor central e o mesmo, antes de atualizar, criarÃ¡ um *snapshot* atual do projeto e entÃ£o atualizarÃ¡.

O Git Ã© organizado por *branches*. Cada *branch* Ã©, tecnicamente, um ponteiro que aponta para algum *snapshot* do projeto em questÃ£o. O *branch* padrÃ£o do Git Ã© o *master*, nele estÃ¡ a versÃ£o mais estÃ¡vel do projeto e sÃ³ deve ser atualizado para outra versÃ£o estÃ¡vel. Para o desenvolvimento em geral outros branches devem ser criados como por exemplo o branch "dev", permitindo assim a possibilidade de trabalhar tranquilamente, sem que erros e bugs atrapalhem o estado estÃ¡vel do projeto.

Todos os arquivos contidos, bem como *branches*, no GitHub sÃ£o identificados por uma chave SHA1 (nÃ£o hÃ¡ outra maneira de identificaÃ§Ã£o, por exemplo, nomes). Ao realizar qualquer operaÃ§Ã£o o Git checa as chaves para garantir a integridade e confiabilidade dos conteÃºdos tornando assim impossÃ­vel a modificaÃ§Ã£o de um arquivo do GitHub sem que o mesmo saiba e registre a mudanÃ§a. O ato de mesclar dois *branches* diferentes chama-se *merge*.

Os arquivos no Git possuem quatro estados diferentes:
* *Untracked*: Nesse estado os arquivos nÃ£o estÃ£o inseridos no GitHub, ele nÃ£o os conhece e nÃ£o gerencia seu histÃ³rico.
* *Unmodified*: Os arquivos nÃ£o estÃ£o modificados, sendo assim o servidor central Git jÃ¡ possui essa mesma versÃ£o dos arquivos. Isso o exclui da necessidade de atualizaÃ§Ã£o quando um **push** for feito, apenas uma referÃªncia Ã  essas versÃµes Ã© passada quando um novo **snapshot** for gerado.
* *Modified*: Os arquivos foram modificados e estÃ£o marcados para atualizaÃ§Ã£o quando um *push* for realizado.
* *Staged*: Os arquivos que foram marcados como modificados sÃ£o empacotados e preparados para serem sincronizados com o servidor central.

Ao ato de sincronizar damos o nome de *commit*.Um *commit* Ã© o envio dos arquivos, empacotados no estÃ¡gio *staged*, para o servidor central. Cada *commit* Ã© identificado pelo nome do usuÃ¡rio que o realizou, seu *email*, uma descriÃ§Ã£o breve do *commit*, uma descriÃ§Ã£o detalhada e por fim uma lista extensa e detalhada dos arquivos modificados e tambÃ©m linhas modificadas.

O ato de enviar arquivos para o servidor central atravÃ©s de um *commit* damos o nome de *push*. AlÃ©m do *push* temos tambÃ©m a aÃ§Ã£o de *pull*. Um *pull* Ã© o processo inverso do *push* sendo assim ao realizar uma sincronia de um servidor local com o servidor central para realizar um *push* pode haver a requisiÃ§Ã£o de um *pull* com os arquivos do servidor central que estÃ£o mais atualizados do que o servidor local.

Por fim, o ato de copiar fielmente um repositÃ³rio e hospeda-lo em sua conta GitHub dÃ¡-se o nome de *Fork*. Criar um *fork* nada mais Ã© do que copiar um repositÃ³rio por completo para sÃ­ para que vocÃª possa usÃ¡-lo como ponto de partida para um projeto prÃ³prio ou entÃ£o para realizar modificaÃ§Ãµes ou correÃ§Ãµes de *bugs* para entÃ£o reenvia-lo para o dono original atravÃ©s de uma *pull request*. Ã‰ visado principalmente para o trabalho em projetos *open source*.

#### O Git no Visual Studio

Com extensÃµes no Visual Studio 2012, e nativamente no Visual Studio 2013,o GitHub Ã© totalmente suportado. Como realizado anteriormente, o repositÃ³rio local estÃ¡ clonado e pronto para uso. Ao abrir o repositÃ³rio local pelo *Team Explorer* as soluÃ§Ãµes contidas nele bem como as opÃ§Ãµes de *branch* e o menu de opÃ§Ãµes:

* *changes*: Que marca todas as mudanÃ§as realizadas no repositÃ³rio local, permite empacota-las em um *commit* bem como decidir manualmente as exclusÃµes do mesmo.
* *branches*: Permite gerenciar os *branches* do repositÃ³rio, criar novos, realizar *merges* e *forks*.
* *unsynced branches*: Permite verificar os arquivos *staged* prontos para o *commit*, resolver conflitos e por fim sincroniza-los com o servidor central.

Se duas ou mais pessoas modificarem o mesmo arquivo em um curto espaÃ§o de tempo uma resoluÃ§Ã£o de conflito serÃ¡ iniciada. Na resoluÃ§Ã£o de conflito hÃ¡ a possibilidade de escolher uma versÃ£o do arquivo, mesclar as duas em uma Ãºnica versÃ£o ou entÃ£o modificar manualmente o arquivo e resolver o conflito.

#### GitHub Website

O *site* do GitHub possui vÃ¡rias ferramentas para gerenciamento do projeto bem como estÃ¡tisticas e *logs*.

Na aba *code* (a *Home* do projeto, por padrÃ£o) encontramos: 
* o cÃ³digo do projeto em sÃ­.
* InformaÃ§Ãµes do Ãºltimo *commit*.
* Menu com informaÃ§Ãµes de todos os *commits*.
* Menu com informaÃ§Ãµes dos *branches*.
* InformaÃ§Ãµes de *releases* (versÃµes definitivas do projeto, por exemplo, versÃ£o 1.0).
* InformaÃ§Ãµes de contribuidores.
* DistribuiÃ§Ã£o de linguagens de programaÃ§Ã£o no projeto.

Na prÃ³xima aba, *issues* encontramos ferramentas para a integraÃ§Ã£o e comunicaÃ§Ã£o da equipe: 
* No primeiro menu, *issues*, temos as ferramentas para a criaÃ§Ã£o, pesquisa e soluÃ§Ã£o de problemas, bugs, idÃ©ias, propsotas, comentÃ¡rios e afins.
* No segundo menu, *pull requests* encontramos as requisiÃ§Ãµes de pull de *terceiros* e hÃ¡ a possibiidade de aceita-las e mescla-las com o *upstream channel*.
* E por fim temos o menu *milestones* que sÃ£o metas estabelecidas e que devem ser cumpridas pelo grupo.
 
Todos os itens criados na aba *issues* podem ser classificados, e pesquisados, com *labels* como *bug*, *enhancement*, *duplicate*, etc.

Na aba *wiki* temos as ferramentas para criar uma *Wiki* prÃ³pria do projeto.

Na aba *pulse* estatÃ­sticas detalhas sÃ£o mostradas e hÃ¡ possibilidade de comparar quaisquer mudanÃ§as.

Em *graphs* temos a visÃ£o detalhada apresentada por meio de grÃ¡ficos:

* *Contributors*: Mostra as contribuiÃ§Ãµes para o projeto por usuÃ¡rio.
* *traffic*: Mostra informaÃ§Ãµes de trafego do projeto, nÃºmeros de views, visitantes, clones, visitantes Ãºnicos e conteÃºdo mais popular.
* *commits*: Mostra detalhadamente o nÃºmero de *commits* por dia e por semana.
* *code frequency*: mostra o nÃºmero de adiÃ§Ãµes e remocÃµes realizadas.
* *punch card*: Mostra os ultimos *commits* com o horÃ¡rio exato.
* *network*: Mostra a movimentaÃ§Ã£o da rede.
* *members*: Mostra os membros que realizaram um *fork* do projeto.
 
Todos os conteÃºdos do GitHub possuem histÃ³rico, arquivos antigos podem ser acessados, tudo pode ser comentado e tudo possui seu respectivo Sha que o identifica.

#### Links Ãšteis

* [Git Documentation](http://git-scm.com/doc)
* [Git no Visual Studio](https://msdn.microsoft.com/pt-br/library/hh850437.aspx)
* [GitHub Help](https://help.github.com/)
* [Markdown Documentation](http://daringfireball.net/projects/markdown/)
