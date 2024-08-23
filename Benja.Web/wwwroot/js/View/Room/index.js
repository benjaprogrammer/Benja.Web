export default class RoomIndex {
	constructor() {
	}
	get area() {
		return this.calcArea();
	}
	GetList() {
		searchnametable = $("#searchnametable").DataTable({
			stateSave: true,
			autoWidth: true,
			processing: true,
			serverSide: true,
			paging: true,
			lengthMenu: [[5, 10, 25, 50, 100, -1], [5, 10, 25, 50, 100, "All"]],
			pageLength: 100,
			pagingType: "full_numbers",
			lengthChange: false,
			searching: { regex: true },
			ajax: {
				url: "/Borderpass/LoadData",
				type: "POST",
				contentType: "application/json",
				dataType: "json",
				data: function (d) {
					//d.param1 = $('#txtSeachName').val();
					//d.param2 = $('#txtSeachSurname').val();
					//d.param3 = $("#ddlSex").val();
					return JSON.stringify(d);
				}
			},
			columns: [
				{
					"name": "ลำดับ",
					"orderable": false,
					"searching": false,
					"className": "text-center",
					"render": function (data, type, row, meta) { return meta.row + 1; },
					"width": '100px'
				},
				{
					data: "name"
				},
				{
					data: "surname"
				},
				{ data: "birthOfDate" },
				{
					data: "documentNo"
				},
				{ data: "sex" },
				{ data: "ethnicity" },
				{ data: "nationality" },
				{
					data: null, render: function (data, type, row) {
						return '<a class="btnedit" type="button" onclick="EditBorderpass(' + data.id + ')"><i class="fas fa-pen-to-square"></i></a>';
					},
					orderable: false, "width": "5%"
				}
			],
		});
	}
}
