//Function para exibir o subMenu ao clicar no botão


    function mostraDiv(idDiv) {
        document.getElementById(idDiv).style.display = "block";
    }

    function fechaDiv(idDiv) {
        document.getElementById(idDiv).style.display = "none";
    }

    var subMenu = 0;
    function mostraDiv1(idDiv) {
        
        subMenu = 1;
        document.getElementById(idDiv).style.display = "block";
    }

    function fechaDiv1(idDiv) {
        document.getElementById(idDiv).style.display = "none";
    }

    function butAcao() {
        subMenu = 1;
    }
    $(document).ready(function () {
        $('body').click(function (e) {
            
            if (subMenu == 1) {
                subMenu = 0;
            } else {
                document.getElementById("ConteudoMenu_ConteudoCentral_subMenu").style.display = "none";
            }
        });
    });
    function toggleDiv(idDiv) {
        if (document.getElementById(idDiv).style.display == "none") {
            subMenu = 1;
            document.getElementById(idDiv).style.display = "block";
        }
        else {
            subMenu = 1;
            document.getElementById(idDiv).style.display = "none";
        }
    }
    