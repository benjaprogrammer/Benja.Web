class Swals {
    constructor() {
    }
    static FireDelete() {
        return Swal.fire({
            title: 'Deleted!',
            text: 'Your file has been deleted.',
            icon: 'success',
            confirmButtonColor: '#3085d6',
            confirmButtonText: 'OK'
        });
    }
    static FireAdd() {
        return Swal.fire({
            title: 'Add!',
            text: 'Your file has been add.',
            icon: 'success',
            confirmButtonColor: '#3085d6',
            confirmButtonText: 'OK'
        });
    }
    static FireEdit() {
        return Swal.fire({
            title: 'Edit!',
            text: 'Your file has been edit.',
            icon: 'success',
            confirmButtonColor: '#3085d6',
            confirmButtonText: 'OK'
        });
    }
}

