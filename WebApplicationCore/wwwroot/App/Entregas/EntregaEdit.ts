namespace EntregaEdit {
    var Entity = $("#AppEdit").data("entity");

    var Formulario = new Vue(
        {
            data:
            {
                Formulario: "#FormEdit",
                Entity: Entity,
                CantonLista: [],
                DistritoLista: [],
            },

            methods: {
                OnChangeProvincia() {
                    Loading.fire("Cargando..");

                    App.AxiosProvider.EntregaChangeProvincia(this.Entity).then(data => {
                        Loading.close();
                        this.CantonLista = data;

                    });


                },

                OnChangeCanton() {
                    Loading.fire("Cargando..");

                    App.AxiosProvider.EntregaChangeCanton(this.Entity).then(data => {
                        Loading.close();
                        this.DistritoLista = data;

                    });


                },

                Save() {
                    if (BValidateData(this.Formulario)) {
                        Loading.fire("Guardando");

                        App.AxiosProvider.EntregaGuardar(this.Entity).then(data => {
                            Loading.close();

                            if (data.CodeError == 0) {
                                Toast.fire({ title: "Se guardó el registro", icon: "success" }).then(() => window.location.href = "Entregas/EntregaGrid")
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
                this.OnChangeProvincia();
                this.OnChangeCanton();

            }
        });

    Formulario.$mount("#AppEdit");
}