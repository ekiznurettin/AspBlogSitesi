$(document).ready(function () {
    const placeHolderDiv = $('#modalPlaceHolder');
    const dataTable = $('#articlesTable').DataTable({
        dom: "<'row'<'col-sm-3'l><'col-sm-5 text-center'B><'col-sm-4'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        /*  buttons: [
             {
                 text: 'Ekle',
                 attr: { id: "btnAdd" },
                 className: 'btn btn-success',
                 action: function (e, dt, node, config) {
                     const url = '/Admin/user/Add/';
                     
                     $.get(url).done(function (data) {
                         placeHolderDiv.html(data);
                         placeHolderDiv.find(".modal").modal('show');
                     });
                 }
             },
            {
                 text: 'Yenile',
                 className: 'btn btn-warning',
                 action: function (e, dt, node, config) {
                     $.ajax({
                         type: 'GET',
                         url: '/Admin/User/GetAllUsers/',
                         contentType: "application/json",
                         beforeSend: function () {
                             $('#usersTable').hide();
                             $('.spinner-border').show();
                         },
                         success: function (data) {
                             const userListDto = jQuery.parseJSON(data);
                             dataTable.clear();
                             console.log(userListDto);
                             if (userListDto.ResultStatus === 0) {
                                 $.each(userListDto.Users.$values, function (index, user) {
                               const = newTableRow=     dataTable.row.Add([
                                    [
                                          `<img src="/Admin/image/${user.Picture}" style="max-height:50px; max-width:50px" alt="${user.UserName}" />`,
                                          User.UserName,
                                          user.Email,
                                          user.PhoneNumber,
                                          `
                                              <button class="btn btn-primary btn-xs btn-update" data-id="${ user.Id}"><span class="fa fa-edit"></span></button>
                                              <button class="btn btn-danger btn-xs btn-delete" data-id="${ user.Id}"><span class="fa fa-minus-circle"></span></button>

                                          `]
                                    ]);
                                 }).node();
                                 const jqueryTableRow=87. ders
                                 dataTable.draw();
                                 $('.spinner-border').hide();
                                 $('#usersTable').fadeIn(500);
                             }
                             else {
                                 toastr.error(`${userListDto.Message}`, 'İşlem Başarısız!');
                             }
                         },
                         error: function (err) {
                             console.log(err);
                             $('.spinner-border').hide();
                             $('#usersTable').fadeIn(500);
                             toastr.error(`${err.responseText}`, 'Hata!');
                         }
                     });
                 }
             }
         ],*/
        language: {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    "1": "1 kayıt seçildi"
                }
            }
        }
    });
    //Datatable end here
    $(function () {
        placeHolderDiv.on('click', '#btnSave', function (event) {
            event.preventDefault();
            const form = $('#form-article-add');
            const actionUrl = form.attr('action');
            const dataToSend = new FormData(form.get(0));
            $.ajax({
                url: actionUrl,
                type: 'POST',
                data: dataToSend,
                processData: false,
                contentType: false,
                success: function (data) {
                    const userAddAjaxModel = jQuery.parseJSON(data);
                    const newFormBody = $('.modal-body', userAddAjaxModel.UserAddPartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const newTableRow = dataTable.row().add([
                            `<img src="/Admin/image/${userAddAjaxModel.UserDto.User.Picture}" class="my-img-table" alt="${userAddAjaxModel.UserDto.User.UserName}" />`,
                            userAddAjaxModel.UserDto.User.Name,
                            userAddAjaxModel.UserDto.User.Surname,
                            convertToShortDate(userAddAjaxModel.UserDto.User.BirthDate),
                            userAddAjaxModel.UserDto.User.BirthPlace,
                            userAddAjaxModel.UserDto.User.Gender,
                            userAddAjaxModel.UserDto.User.UserName,
                            userAddAjaxModel.UserDto.User.Email,
                            userAddAjaxModel.UserDto.User.PhoneNumber,
                            userAddAjaxModel.UserDto.User.Status,
                            `<button class="btn btn-primary btn-xs btn-update" data-id="${userAddAjaxModel.UserDto.User.Id}"><span class="fa fa-edit"></span></button>
                                <button class="btn btn-danger btn-xs btn-delete" data-id="${userAddAjaxModel.UserDto.User.Id}"><span class="fa fa-minus-circle"></span></button>`
                        ]).node();
                        const jqueryTableRow = $(newTableRow);
                        jqueryTableRow.attr('name', `${userAddAjaxModel.UserDto.User.Id}`);
                        dataTable.row(newTableRow).draw();
                        toastr.success(`${userAddAjaxModel.UserDto.message} adlı kategori başarıyla gerçekleşti`, 'Başarılı işlem');
                    }
                    else {
                        let summaryText = "";
                        $('#validation-summary>ul>li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                },
                error: function (err) {
                    toastr.error(`${err.responseText}`, "Hata!");
                }
            });
        });
    });

    $(document).on('click', '.btn-add', function () {
        const url = '/Admin/Article/Add/';

        $.get(url).done(function (data) {
            placeHolderDiv.html(data);
            placeHolderDiv.find(".modal").modal('show');
        });
    });


    $(document).on('click', '.btn-delete', function () {
        event.preventDefault();
        const id = $(this).attr('data-id');
        const tableRow = $(`[name="${id}"]`);
        const articleTitle = tableRow.find('td:eq(2)').text();
        Swal.fire({
            title: 'Silmek İstediğinize Emin misiniz?',
            text: `${articleTitle} başlıklı makale Silinecektir!`,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet',
            cancelButtonText: 'Hayır'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    data: { articleId: id },
                    url: '/Admin/Article/Delete/',
                    success: function (data) {
                        const articleResult = jQuery.parseJSON(data);
                        if (articleResult.ResultStatus === 0) {
                            Swal.fire(
                                'Silindi!',
                                `${articleResult.Message}`,
                                'success'
                            );

                            dataTable.row(tableRow).remove().draw();
                        }
                        else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Başarısız İşlem...',
                                text: `${articleResult.Message}`
                            });
                        }
                    },
                    error: function (err) {
                        console.log(err);
                        toastr.error(`${err.responseText}`, "Hata!");
                    }
                });
            }

        })
    });

    $(function () {
        const url = '/Admin/User/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click', '.btn-update', function (event) {
            event.preventDefault();
            const id = $(this).attr("data-id");
            $.get(url, { userId: id }).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find('.modal').modal('show');
            }).fail(function () {
                toastr.error("Bir Hata Oluştu", "Hata");
            });
        });

        placeHolderDiv.on('click', '#btnUpdate', function (event) {
            event.preventDefault();
            const form = $('#form-article-update');
            const actionUrl = form.attr('action');
            const dataToSend = new FormData(form.get(0));
            $.ajax({
                url: actionUrl,
                type: 'POST',
                data: dataToSend,
                processData: false,
                contentType: false,
                success: function (data) {
                    const userUpdateAjaxModel = jQuery.parseJSON(data);
                    console.log(userUpdateAjaxModel);
                    if (userUpdateAjaxModel.UserDto != null) {
                        const id = userUpdateAjaxModel.UserDto.User.Id;
                        const tableRow = $(`[name="${id}"]`);
                    }
                    const newFormBody = $('.modal-body', userUpdateAjaxModel.UserUpdatePartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        dataTable.row(tableRow).data([
                            `<img src="/Admin/image/${userUpdateAjaxModel.UserDto.User.Picture}" class="my-img-table" alt="${userUpdateAjaxModel.UserDto.User.UserName}" />`,
                            userUpdateAjaxModel.UserDto.User.Name,
                            userUpdateAjaxModel.UserDto.User.Surname,
                            convertToShortDate(userUpdateAjaxModel.UserDto.User.BirthDate),
                            userUpdateAjaxModel.UserDto.User.BirthPlace,
                            userUpdateAjaxModel.UserDto.User.Gender,
                            userUpdateAjaxModel.UserDto.User.UserName,
                            userUpdateAjaxModel.UserDto.User.Email,
                            userUpdateAjaxModel.UserDto.User.PhoneNumber,
                            userUpdateAjaxModel.UserDto.User.Status,
                            `<button class="btn btn-primary btn-xs btn-update" data-id="${userUpdateAjaxModel.UserDto.User.Id}"><span class="fa fa-edit"></span></button>
                                <button class="btn btn-danger btn-xs btn-delete" data-id="${userUpdateAjaxModel.UserDto.User.Id}"><span class="fa fa-minus-circle"></span></button>`
                        ]);
                        tableRow.attr("name", `${id}`);
                        dataTable.row(tableRow).invalidate();
                        toastr.success(`${userUpdateAjaxModel.UserDto.Message}`, "Başarılı İşlem!");
                    } else {
                        let summaryText = "";
                        $('#validation-summary>ul>li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                },
                error: function (err) {
                    toastr.error(`${err.responseText}`,"Hata!");
                }
            });
        });
    });
});