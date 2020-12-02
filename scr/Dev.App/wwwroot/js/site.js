$(document).ready(function () {
    $('#msg_box').fadeOut(2500);
    //--Inicial o select
    inicializaDropDown();
    //--Mascara de money
    $('.money-mask').maskMoney({ prefix: 'R$ ', precision: 2, thousands: '.', decimal: ',', affixesStay: false });
    //--Mascara de datas
    flatpickr(".date-mask", { dateFormat: "d/m/Y", locale: "pt" });
    flatpickr(".date-range-mask", { dateFormat: "d/m/Y", locale: "pt", mode: "range" });

    //$('.ui.accordion').accordion();
});

inicializaDropDown = () => {
    $('.ui.selection.dropdown').dropdown();
    $('.ui.pointing.dropdown').dropdown();
    $('.ui.fluid.dropdown').dropdown({
        allowAdditions: true
    });
}

showInToast = (icon, title) => {

    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 4000,
        timerProgressBar: true,
        background: '#39a275'
    });

    Toast.fire({
        icon: icon,
        title: '<span class="text-white">' + title + '</span>'
    });
};

filtraProjetos = form => {

    try {
        $.ajax({
            type: "POST",
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $("#lista-html").html(res.html);
                    inicializaDropDown();
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    } catch (e) {
        console.log(e);
    }

    //to prevent default form submit event
    return false;
};

jQueryAjaxDelete = form => {

    Swal.fire({
        title: 'Atenção!',
        text: "Você deseja realmente excluir esse PSP?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#007bff',
        confirmButtonText: 'Sim, confirmar exclusão!',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.value) {
            try {
                $.ajax({
                    type: "POST",
                    url: form.action,
                    data: new FormData(form),
                    contentType: false,
                    processData: false,
                    success: function (res) {
                        $("#lista-html").html(res.html);

                        inicializaDropDown();

                        showInToast('success', 'Projeto deletado com sucesso');
                    },
                    error: function (err) {
                        console.log(err);
                    }
                });
            } catch (e) {
                console.log(e);
            }
        }
    });

    //to prevent default form submit event
    return false;
}

BuscaCliente = () => {
    $(document).ready(function () {
        function limpa_formulario_cliente() {
            // Limpa valores do formulário de cep.
            $("#Customer_CNPJ").val("");
            $("#Customer_Email").val("");
            $("#Customer_Name").val("");
            $("#Customer_SegmentId").dropdown('clear');
        }

        //Quando o campo cep perde o foco.
        $("#Customer_CNPJ").blur(function () {
            //Nova variável "cnpj" somento com os digítos.
            var cnpj = $(this).val().replace(/[^\d]+/g, '');
            //Verifica se o campo cnpj possui valor informado
            if (cnpj != "") {
                //Preenche os campos com "..." enquanto consulta webservice
                $("#Customer_Email").val("...");
                $("#Customer_Name").val("...");

                $.ajax({
                    type: "GET",
                    url: "https://www.receitaws.com.br/v1/cnpj/" + cnpj,
                    contentType: "application/json; charset=utf-8",
                    data: "{}",
                    crossDomain: true,
                    dataType: "jsonp",
                    success: function (data) {
                        $("#Customer_Email").val(data.email);
                        $("#Customer_Name").val(data.nome);
                    },
                    error: function (e) {
                        alert(e);
                    }
                });

            }
            else {
                limpa_formulario_cliente();
            }
        });
    });
}

PostCustomer = form => {
    try {
        $.ajax({
            type: "POST",
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (result) {
                if (result.isValid) {
                    $('#btn-close-modal').click();

                    $('#txtCustomer').val(result.cliente.name);
                    $('#CustomerId').val(result.cliente.id);

                } else {
                    $("#myModalContent").html(result.html);
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    } catch (e) {
        console.log(e);
    }

    return false;
};
