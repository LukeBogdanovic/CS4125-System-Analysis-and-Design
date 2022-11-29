$(document).ready(function () {
  let table = $("#Rooms").DataTable({
    ajax: {
      url: "/rooms/getAll",
    },
    columns: [
      {
        data: "name",
        render: function (data, type, room) {
          return (
            "<a href='/rooms/details/" + room.id + "'>" + room.name + "</a>"
          );
        },
      },
      {
        data: "capacity",
      },
      {
        data: "floor",
      },
      {
        data: "id",
        render: function (data) {
          return `<a class='btn-link' href='/rooms/edit/${data}'><i class='bi bi-pencil-square' style='color:#75caeb'; cursor:pointer;'></i></a>
                <a class='btn-link js-delete' data-rooms-id=${data}><i class='bi bi-trash-fill' style='color: #ff4136; cursor:pointer;'></i></a>`;
        },
      },
    ],
  });
  $("#Rooms").on("click", ".js-delete", function () {
    let button = $(this);
    Swal.fire({
      title: `Are you sure you want to delete this room ?`,
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#d33",
      cancelButtonColor: "#5ea2bc",
      confirmButtonText: "Confirm",
    })
      .then((result) => {
        if (result.isConfirmed) {
          $.ajax({
            url: "/rooms/delete/" + button.attr("data-rooms-id"),
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
});
