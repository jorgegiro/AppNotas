// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('a[data-toggle=popover]').popover();

    $(".btn-submit").click(function (e) {
        e.preventDefault();
        var element = $(this);
        element.parent().submit();
    });

    $('#modalBorrado').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget) // Button that triggered the modal
        var idNota = button.data('id')

        var modal = $(this)
        modal.find('#idNotaBorrado').val(idNota)
    });

    $("#buscadorNotas").keyup(function (event) {

        var textoABuscar = $("#buscadorNotas").val();

        if (textoABuscar == undefined || textoABuscar == null || textoABuscar == "undefined")
        {
            textoABuscar = "";
        }

        $.get("/Notas/BuscarNotas/", { text: textoABuscar, pagina: 0 })
            .done(function (data) {
                $('#contenidoNotas').html(data);

                //$("[data-target='#modalBorrado']").click(function () {
                //    console.log("Ha hecho click");
                //    $("#modalBorrado").modal('toggle');
                //});
        });
    });

    $('#editarNota textarea').summernote({        
        toolbar: [
            ['style', ['bold', 'italic', 'underline', 'clear']],
            ['font', ['strikethrough', 'superscript', 'subscript']],
            ['color', ['forecolor']]
        ]
    });

    $('.note-link-popover, .note-image-popover, .note-table-popover').remove();
});



