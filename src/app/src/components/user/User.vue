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
				:items="users"
				:items-per-page="10"
				class="elevation-1"
			>
				<template v-slot:item.action="{ item }">
					<v-icon small class="mr-2" color="info" @click="editItem(item)">edit</v-icon>
					<v-icon small color="error" @click="deleteUser(item)">delete</v-icon>
				</template>
			</v-data-table>
		</v-card>
		<v-dialog persistent v-model="dialog" width="500">
			<create-user v-if="dialog" @createUser="createUser" @close="closeDialog"></create-user>
		</v-dialog>
	</v-container>
</template>

<script>
import urls from "../../urls";
import createUser from "./createUser";
import edirUser from "./editUser";

export default {
	data: () => ({
		search: "",
		headers: [
			{ text: "#", value: "id" },
			{ text: "Nome", value: "name" },
			{ text: "email", value: "apartament" },
			{ text: "Actions", value: "action", sortable: false }
		],
		users: [],
		dialog: false,
		userEditData: {}
	}),
	methods: {
		async getAllUsers() {
			try {
				const responseData = await this.$http.get(urls.user.getAll);
				return responseData.data;
			} catch (error) {
				alert("Não foi possível buscar os usuários");
			}
		},
		async deleteUser(user) {
			const confirmMessage = "Você deseja deletar o usuário?";
			if (confirm(confirmMessage)) {
				await this.$http.delete(urls.user.delete.replace("@id", user.id));
				this.removeUserFromArray(user);
			}
		},
		removeUserFromArray(user) {
			const userIndex = this.users.indexOf(user);
			this.users.splice(userIndex, 1);
		},
		closeDialog() {
			this.dialog = false;
		},
		openDialog() {
			this.dialog = true;
		},
		async createUser(userData) {
			try {
				this.closeDialog();
				const response = await this.$http.post(urls.user.create, userData);
				alert("Usuário criado com sucesso");
				this.users = await this.getAllUsers();
			} catch (error) {
				error.response.data
					? alert(error.response.data)
					: alert("Não foi possível cadastrar");
			}
		}
	},
	async created() {
		this.users = await this.getAllUsers();
	},
	components: {
		createUser,
		edirUser
	}
};
</script>
