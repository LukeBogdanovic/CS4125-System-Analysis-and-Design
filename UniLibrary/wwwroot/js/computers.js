$(document).ready(function () {
  var table = $("#computers").DataTable({
    ajax: {
      url: "/computers/getAll",
    },
    columns: [
      {
        data: "comNum",
      },
      {
        data: "os",
      },
      {
        data: "availability",
        render: function (data) {
          let availability = "Available";
          if (!data) {
            availability = "Not Available";
          }
          return `<td>${availability}</td>`;
        },
      },
      {
        data: "id",
        render: function (data) {
          return `<a class='btn-link js-loan' data-computer-id=${data}><i class='bi bi-cart-plus' style='color:#00FF00'; cursor:pointer;'></i></a>
                        <a class='btn-link js-return' data-computer-id=${data}><i class='bi bi-arrow-return-right' style='color:#FFA500'; cursor:pointer;'></i></a>
                        <a class='btn-link' href='/computers/edit/${data}'><i class='bi bi-pencil-square' style='color:#75caeb'; cursor:pointer;'></i></a>
                        <a class='btn-link js-delete' data-computer-id=${data}><i class='bi bi-trash-fill' style='color: #ff4136; cursor:pointer;'></i></a>`;
        },
        className: "text-light dt-body-center",
      },
    ],
  });
  $("#computers").on("click", ".js-delete", function () {
    let button = $(this);
    Swal.fire({
      title: `Are you sure you want to delete this Computer ?`,
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#d33",
      cancelButtonColor: "#5ea2bc",
      confirmButtonText: "Confirm",
    })
      .then((result) => {
        if (result.isConfirmed) {
          $.ajax({
            url: "/computers/delete/" + button.attr("data-computer-id"),
            type: "DELETE",
            success: function (data) {
              if (data) {
                if (data.success) {
                  table.ajax.reload();
                  toastr.success(data.message);
                  table.row(button.parents("tr")).remove().draw();
                } else {
                  toastr.error(data.message);
                }
              }
            },
          });
        }
      })
      .catch(() => {
        toastr.error("An unexpected error occurred please try again later !");
      });
  });
  $("#computers").on("click", ".js-loan", function () {
    let button = $(this);
    Swal.fire({
      title: `Are you sure you want to use this computer ?`,
      icon: "question",
      showCancelButton: true,
      confirmButtonColor: "#d33",
      cancelButtonColor: "#5ea2bc",
      confirmButtonText: "Confirm",
    }).then((result) => {
      if (result.isConfirmed) {
        $.ajax({
          url: "/computers/loan/" + button.attr("data-computer-id"),
          type: "POST",
          success: function (data) {
            if (data) {
              if (data.success) {
                table.ajax.reload();
                toastr.success(data.message);
              } else {
                toastr.error(data.message);
              }
            }
          },
        });
      }
    });
  });
  $("#computers").on("click", ".js-return", function () {
    let button = $(this);
    Swal.fire({
      title: `Are you sure you want to return this computer ?`,
      icon: "question",
      showCancelButton: true,
      confirmButtonColor: "#d33",
      cancelButtonColor: "#5ea2bc",
      confirmButtonText: "Confirm",
    }).then((result) => {
      if (result.isConfirmed) {
        $.ajax({
          url: "/computers/return/" + button.attr("data-computer-id"),
          type: "POST",
          success: function (data) {
            if (data) {
              if (data.success) {
                table.ajax.reload();
                toastr.success(data.message);
              } else {
                toastr.error(data.message);
              }
            }
          },
        });
      }
    });
  });
});
