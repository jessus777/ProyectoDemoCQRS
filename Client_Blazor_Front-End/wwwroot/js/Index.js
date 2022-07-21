function spinnerLoadingHide() {
    $('#spinnerLoad').hide();
}

function spinnerLoadingShow() {
    $('#spinnerLoad').show();
}


async function showAlertQuestionAsync(isAlertAdd = false, title = '', text = '', confirmTex = "", cancelText = "") {
    if (isAlertAdd) {
        return new Promise(resolve => {
            swalWithBootstrapButtonsQuestionAdd.fire({
                title: title,
                text: text,
                icon: 'question',
                iconColor: 'blue',
                showCancelButton: true,
                confirmButtonText: '<i class="bi bi-hand-thumbs-up-fill"> </i>' + confirmTex,
                cancelButtonText: '<i class="bi bi-x-circle-fill"> </i> ' + cancelText,
                reverseButtons: false,
                focusCancel: true
            }).then((result) => {
                resolve(result.isConfirmed);
            })
        })
    }
    else {
        return new Promise(resolve => {
            swalWithBootstrapButtonsQuestionDelete.fire({
                title: title,
                text: text,
                icon: 'question',
                iconColor: 'blue',
                showCancelButton: true,
                confirmButtonText: '<i class="bi bi-trash-fill"> </i>' + confirmTex,
                cancelButtonText: '<i class="bi bi-x-circle-fill"> </i> ' + cancelText,
                reverseButtons: false,
                focusCancel: true
            }).then((result) => {
                console.log(result);
                resolve(result.isConfirmed);
            })
        })

    }
}

async function showAlertWarning(title = '', text = '', confirmTex = "", cancelText = "") {
    return new Promise(resolve => {
        swalWithBootstrapButtonsWarning.fire({
            title: title,
            text: '<strong>' + text + '</strong>',
            icon: 'warning',
            iconColor: 'orange',
            showCancelButton: true,
            confirmButtonText: '<i class="bi bi-reply-all-fill"> </i> ' + confirmTex,
            cancelButtonText: '<i class="bi bi-x-circle-fill"> </i> ' + cancelText,
            reverseButtons: false,
            focusCancel: true
        }).then((result) => {
            console.log(result.isConfirmed);
            resolve(result.isConfirmed);
        })
    });

}

function confirmAlert(icon = '',iconColor='', title='', text='') {
    Swal.fire({
        position: 'center',
        icon: icon,
        iconColor: iconColor, //    '#198754'
        title: title,
        text: text,
        showConfirmButton: false,
        timer: 1800
    })
}

async function confirmAlertAsync(icon = '', iconColor = '', title = '', text = '') {
    return new Promise(resolve => {
        Swal.fire({
            position: 'center',
            icon: icon,
            iconColor: iconColor, //    '#198754'
            title: title,
            text: text,
            showConfirmButton: false
        })
        setTimeout(() => {
            resolve(true);
        }, 1800)
    });
}


function showToast() {
    const toastTrigger = document.getElementById('liveToastBtn')
    const toastLiveExample = document.getElementById('liveToast')
    if (toastTrigger) {
        toastTrigger.addEventListener('click', () => {
            const toast = new bootstrap.Toast(toastLiveExample)

            toast.show()
        })
    }
}


const swalWithBootstrapButtonsWarning = Swal.mixin({
    customClass: {
        confirmButton: 'btn btn-warning shadow rounded',
        cancelButton: 'btn btn-secondary shadow rounded'
    },
    buttonsStyling: false
})

const swalWithBootstrapButtonsQuestionDelete = Swal.mixin({
    customClass: {
        confirmButton: 'btn btn-danger shadow rounded',
        cancelButton: 'btn btn-secondary shadow rounded'
    },
    buttonsStyling: false
})

const swalWithBootstrapButtonsQuestionAdd = Swal.mixin({
    customClass: {
        confirmButton: 'btn btn-primary shadow rounded',
        cancelButton: 'btn btn-secondary shadow rounded'
    },
    buttonsStyling: false
})

function dataTable() {

    $('#table_id').DataTable({
      /*  responsive: true,*/
        scrollY: 500,
        scrollX: true,
        bDestroy: true,
       
/*        stateSave: true,*/
        "language": {
            "processing": "Procesando...",
            "lengthMenu": "Mostrar _MENU_ registros",
            "zeroRecords": "No se encontraron resultados",
            "emptyTable": "Ningún dato disponible en esta tabla",
            "infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "infoFiltered": "(filtrado de un total de _MAX_ registros)",
            "search": "Buscar:",
            "infoThousands": ",",
            "loadingRecords": "Cargando...",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            },
            "info": "Mostrando _START_ a _END_ de _TOTAL_ registros"
        }
    });
}