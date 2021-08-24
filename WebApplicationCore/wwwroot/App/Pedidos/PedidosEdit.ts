namespace PedidossEdit {

    var Entity = $("#AppEdit").data("entity");

    var Formulario = new Vue(
        {
            data:
            {
                Formulario: "#FormEdit",
                Entity: Entity,
                ProductosLista: [],
                
            },

            methods: {
                OnChangeCategoria() {
                    Loading.fire("Cargando..");

                    App.AxiosProvider.PedidosChangeCategoria(this.Entity).then(data => {
                        Loading.close();
                        this.ProductosLista = data;

                    });


                },

                Save() {
                    if (BValidateData(this.Formulario)) {
                        Loading.fire("Guardando");

                        App.AxiosProvider.PedidosGuardar(this.Entity).then(data => {
                            Loading.close();

                            if (data.CodeError == 0) {
                                Toast.fire({ title: "Se guardó el pedido", icon: "success" }).then(() => window.location.href = "Agencia/Grid")
                            }
                            else {
                                Toast.fire({ title: data.MsgError, icon: "error" })

                            }

                        });
                    } else {

                        Toast.fire({ title: "Por favor complete los campos requeridos" });
                    }

                }
            },

            mounted() {
                CreateValidator(this.Formulario);

            },
            created() {
               this.OnChangeCategoria();
            }
        } );

    Formulario.$mount("#AppEdit");
}