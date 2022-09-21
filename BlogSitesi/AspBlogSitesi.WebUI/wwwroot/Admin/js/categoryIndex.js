$(document).ready(function () {
    const placeHolderDiv = $('#modalPlaceHolder');
    $('#categoriesTable').DataTable({
        dom: "<'row'<'col-sm-3'l><'col-sm-5 text-center'B><'col-sm-4'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        /*  buttons: [
             {
                 text: 'Ekle',
                 attr: { id: "btnAdd" },
                 className: 'btn btn-success',
                 action: function (e, dt, node, config) {
                     const url = '/Admin/Category/Add/';
                     
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
                         url: '/Admin/Category/GetAllCategories/',
                         contentType: "application/json",
                         beforeSend: function () {
                             $('#categoriesTable').hide();
                             $('.spinner-border').show();
                         },
                         success: function (data) {
                             const categoryListDto = jQuery.parseJSON(data);
                             console.log(categoryListDto);
                             if (categoryListDto.ResultStatus === 0) {
                                 let tableBody = "";
                                 $.each(categoryListDto.Categories.$values, function (index, category) {
                                     tableBody += `
                                   <tr name="${category.Id}">
                                       <td>${category.Id}</td>
                                       <td>${category.Name}</td>
                                       <td>${category.Description}</td>
                                       <td>${convertFirstLetterToUpperCase(category.IsActive.toString())}</td >
                                       <td>${convertFirstLetterToUpperCase(category.IsDeleted.toString())}</td >
                                       <td>${category.Note}</td>
                                       <td>${convertToShortDate(category.CreatedDate)}</td >
                                       <td>${category.CreatedByName}</td>
                                       <td>${convertToShortDate(category.ModifiedDate)}</td >
                                       <td>${category.ModifiedByName}</td>
                                       <td>
                                          <button class="btn btn-primary btn-xs btn-update" data-id="${Category.Id}><span class="fa fa-edit"></span></button>
                                          <button class="btn btn-danger btn-xs btn-delete" data-id="${category.Id}"><span class="fa fa-minus-circle"></span></button>
                                       </td>
                                  </tr>`;
                                 });
                                 $('#categoriesTable > tbody').replaceWith(tableBody);
                                 $('.spinner-border').hide();
                                 $('#categoriesTable').fadeIn(500);
                             }
                             else {
                                 toastr.error(`${categoryListDto.Message}`, 'İşlem Başarısız!');
                             }
                         },
                         error: function (err) {
                             console.log(err);
                             $('.spinner-border').hide();
                             $('#categoriesTable').fadeIn(500);
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
            const form = $('#form-category-add');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function (data) {
                const categoryAddAjaxModel = jQuery.parseJSON(data);
                const newFormBody = $('.modal-body', categoryAddAjaxModel.CategoryAddPartial);
                placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    placeHolderDiv.find('.modal').modal('hide');
                    const newTableRow = `
                          <tr name ="${categoryAddAjaxModel.CategoryDto.Category.Id}">
                            <td>${categoryAddAjaxModel.CategoryDto.Category.Id}</td>
                            <td>${categoryAddAjaxModel.CategoryDto.Category.Name}</td>
                            <td>${categoryAddAjaxModel.CategoryDto.Category.Description}</td>
                            <td>${categoryAddAjaxModel.CategoryDto.Category.IsActive ? "Evet" : "Hayır"}</td>
                            <td>${categoryAddAjaxModel.CategoryDto.Category.IsDeleted ? "Evet" : "Hayır"}</td>
                            <td>${categoryAddAjaxModel.CategoryDto.Category.Note}</td>
                            <td>${convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.CreatedDate)}</td>
                            <td>${categoryAddAjaxModel.CategoryDto.Category.CreatedByName}</td>
                            <td>${convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.ModifiedDate)}</td>
                            <td>${categoryAddAjaxModel.CategoryDto.Category.ModifiedByName}</td>
                            <td>
                               <button class="btn btn-primary btn-xs btn-update" data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}><span class="fa fa-edit"></span></button>
                               <button class="btn btn-danger btn-xs btn-delete" data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}"><span class="fa fa-minus-circle"></span></button>
                            </td>
                        </tr>`;
                    const newTableRowObject = $(newTableRow);
                    newTableRowObject.hide();
                    $('#categoriesTable').append(newTableRowObject);
                    newTableRowObject.fadeIn(2500);

                    toastr.success(`${categoryAddAjaxModel.categoryDto.message} adlı kategori başarıyla gerçekleşti`, 'Başarılı işlem');
                }
                else {
                    let summaryText = "";
                    $('#validation-summary>ul>li').each(function () {
                        let text = $(this).text();
                        summaryText = `*${text}\n`;
                    });
                    toastr.warning(summaryText);
                }
            });
        });
    });

    $(document).on('click', '.btn-add', function () {
        const url = '/Admin/Category/Add/';

        $.get(url).done(function (data) {
            placeHolderDiv.html(data);
            placeHolderDiv.find(".modal").modal('show');
        });
    });


    $(document).on('click', '.btn-delete', function () {
        event.preventDefault();
        const id = $(this).attr('data-id');
        const tableRow = $(`[name="${id}"]`);
        const categoryName = tableRow.find('td:eq(1)').text();
        Swal.fire({
            title: 'Silmek İstediğinize Emin misiniz?',
            text: `${categoryName} Adlı Kategori Silinecektir!`,
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
                    data: { categoryId: id },
                    url: '/Admin/Category/Delete/',
                    success: function (data) {
                        const categoryDto = jQuery.parseJSON(data);
                        if (categoryDto.ResultStatus === 0) {
                            Swal.fire(
                                'Silindi!',
                                `${categoryDto.Message}`,
                                'success'
                            );

                            tableRow.fadeOut(500);
                        }
                        else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Başarısız İşlem...',
                                text: `${categoryDto.Message}`
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
        const url = '/Admin/Category/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click', '.btn-update', function (event) {
            event.preventDefault();
            const id = $(this).attr("data-id");
            $.get(url, { categoryId: id }).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find('.modal').modal('show');
            }).fail(function () {
                toastr.error("Bir Hata Oluştu", "Hata");
            });
        });

        placeHolderDiv.on('click', '#btnUpdate', function (event) {
            event.preventDefault();
            const form = $('#form-category-update');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function (data) {
                const categoryUpdateAjaxModel = jQuery.parseJSON(data);
                const newFormBody = $('.modal-body', categoryUpdateAjaxModel.CategoryUpdatePartial);
                placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    placeHolderDiv.find('.modal').modal('hide');
                    const newTableRow = `
                          <tr name=${categoryUpdateAjaxModel.CategoryDto.Category.Id}>
                            <td>${categoryUpdateAjaxModel.CategoryDto.Category.Id}</td>
                            <td>${categoryUpdateAjaxModel.CategoryDto.Category.Name}</td>
                            <td>${categoryUpdateAjaxModel.CategoryDto.Category.Description}</td>
                            <td>${categoryUpdateAjaxModel.CategoryDto.Category.IsActive?"Evet":"Hayır"}</td>
                            <td>${categoryUpdateAjaxModel.CategoryDto.Category.IsDeleted?"Evet":"Hayır"}</td>
                            <td>${categoryUpdateAjaxModel.CategoryDto.Category.Note}</td>
                            <td>${convertToShortDate(categoryUpdateAjaxModel.CategoryDto.Category.CreatedDate)}</td>
                            <td>${categoryUpdateAjaxModel.CategoryDto.Category.CreatedByName}</td>
                            <td>${convertToShortDate(categoryUpdateAjaxModel.CategoryDto.Category.ModifiedDate)}</td>
                            <td>${categoryUpdateAjaxModel.CategoryDto.Category.ModifiedByName}</td>
                            <td>
                               <button class="btn btn-primary btn-xs btn-update" data-id="${categoryUpdateAjaxModel.CategoryDto.Category.Id}><span class="fa fa-edit"></span></button>
                               <button class="btn btn-danger btn-xs btn-delete" data-id="${categoryUpdateAjaxModel.CategoryDto.Category.Id}"><span class="fa fa-minus-circle"></span></button>
                            </td>
                        </tr>`;
                    const newTableRowObject = $(newTableRow);
                    const categoryTableRow = $(`[name="${categoryUpdateAjaxModel.CategoryDto.Category.Id}"]`);
                    newTableRowObject.hide();
                    categoryTableRow.replaceWith(newTableRowObject);
                    newTableRowObject.fadeIn(500);
                    toastr.success(`${categoryUpdateAjaxModel.CategoryDto.Message}`, "Başarılı İşlem!");
                } else {
                    let summaryText = "";
                    $('#validation-summary>ul>li').each(function () {
                        let text = $(this).text();
                        summaryText = `*${text}\n`;
                    });
                    toastr.warning(summaryText);
                }
            }).fail(function (response) {
                console.log(response);
            });
        });
    });
});