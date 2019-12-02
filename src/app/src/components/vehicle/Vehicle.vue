<template>
	<v-container grid-list-xs>
		<v-card>
			<v-card-title>
				Veículos
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
					<v-icon small color="error" @click="deleteVehicle(item)">delete</v-icon>
				</template>
			</v-data-table>
		</v-card>
		<v-dialog persistent v-model="dialogCreate" width="500">
			<create-vehicle v-if="dialogCreate" @close="closeDialog" @createVehicle="createNewVehicle"></create-vehicle>
		</v-dialog>
		<v-dialog persistent v-model="dialogEdit" width="500">
			<edit-vehicle
				v-if="dialogEdit"
				:vehicleData="vehicleEditData"
				@close="closeDialog"
				@editVehicle="editVehicleData"
			></edit-vehicle>
		</v-dialog>
	</v-container>
</template>

<script>
import urls from "../../urls";
import createVehicle from "./CreateVehicle";
import editVehicle from "./EditVehicle";

export default {
	data: () => ({
		search: "",
		headers: [
			{ text: "Placa", value: "plate.value" },
			{ text: "Modelo", value: "model" },
			{ text: "Cor", value: "color" },
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
		openDialogEdit(vehicle) {
			this.vehicleEditData = vehicle;
			this.dialogEdit = true;
		},
		closeDialog() {
			this.dialogCreate = false;
			this.dialogEdit = false;
		},
		async createNewVehicle(data) {
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

			this.vehicles = await this.getAllVehicles();
		},
		async deleteVehicle(vehicle) {
			const confirmMessage = "Você deseja deletar o Veículo?";
			if (confirm(confirmMessage)) {
				await this.$http.delete(
					urls.vehicle.delete.replace("@plate", vehicle.plate.value)
				);
				this.removeUserFromArray(vehicle);
			}
		},
		async editVehicleData(vehicleData) {
			this.closeDialog();
			try {
				await this.$http.put(
					urls.vehicle.edit.replace("@plate", vehicleData.plate),
					vehicleData
				);
				alert("Veículo editado com sucesso");

				this.vehicles = await this.getAllVehicles();
			} catch (error) {
				error.response.data
					? alert(error.response.data)
					: alert("Não foi possível editar");
			}
		},
		removeUserFromArray(vehicle) {
			const vehicleIndex = this.vehicles.indexOf(vehicle);
			this.vehicles.splice(vehicleIndex, 1);
		}
	},
	async created() {
		this.vehicles = await this.getAllVehicles();
	},
	components: {
		createVehicle,
		editVehicle
	}
};
</script>
