<template>
	<v-container grid-list-xs>
		<v-card>
			<v-card-title>
				Usuários
				<div class="flex-grow-1"></div>
				<v-text-field v-model="search" label="Buscar" append-icon="search" single-line hide-details></v-text-field>
				<v-fab-transition>
					<v-btn @click="openDialog()" color="success" fab dark small top right>
						<v-icon>mdi-plus</v-icon>
					</v-btn>
				</v-fab-transition>
			</v-card-title>
			<v-data-table
				:search="search"
				:headers="headers"
				:items="vehicles"
				:items-per-page="10"
				class="elevation-1"
			>
				<template v-slot:item.action="{ item }">
					<v-icon small class="mr-2" color="info" @click="openDialogEdit(item)">edit</v-icon>
					<v-icon small color="error" @click="deleteUser(item)">delete</v-icon>
				</template>
			</v-data-table>
		</v-card>
		<v-dialog persistent v-model="dialogCreate" width="500">
			<create-vehicle v-if="dialogCreate" @close="closeDialog" @createVehicle="createNewVehicle"></create-vehicle>
		</v-dialog>
		<v-dialog persistent v-model="dialogEdit" width="500"></v-dialog>
	</v-container>
</template>

<script>
import urls from "../../urls";
import createVehicle from "./CreateVehicle";

export default {
	data: () => ({
		search: "",
		headers: [
			{ text: "Placa", value: "plate" },
			{ text: "Modelo", value: "model" },
			{ text: "Cor", value: "color" },
			{ text: "Dono", value: "clientId" },
			{ text: "", value: "action", sortable: false }
		],
		vehicles: [],
		dialogCreate: false,
		dialogEdit: false,
		vehicleEditData: {}
	}),
	methods: {
		async getAllVehicles() {
			try {
				const responseData = await this.$http.get(urls.vehicle.getAll);
				return responseData.data;
			} catch (error) {
				alert("Não foi possível buscar os veículos!");
			}
		},
		openDialog() {
			this.vehicleEditData = {};
			this.dialogCreate = true;
		},
		closeDialog() {
			this.dialogCreate = false;
			this.dialogEdit = false;
		},
		async createNewVehicle(data) {
			console.clear();
			console.log(data);

			this.closeDialog();

			try {
				const response = await this.$http.post(urls.vehicle.create, data);
				alert("Veículo criado com sucesso");
				this.users = await this.getAllUsers();
			} catch (error) {
				error.response.data
					? alert(error.response.data)
					: alert("Não foi possível cadastrar");
			}
		}
	},
	async created() {
		this.vehicles = await this.getAllVehicles();
	},
	components: {
		createVehicle
	}
};
</script>
