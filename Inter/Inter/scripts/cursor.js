   $(document).ready(function (e) {
            $(this).bind('keydown', 'alt+f10', function () {
                $('#txtLoginM').toggleClass('hidden')
                $('#txtSenhaM').toggleClass('hidden')
                $('#btnEnviarM').toggleClass('hidden');
                $("#lblMsgErroM").toggleClass('hidden');
               
            });
        });