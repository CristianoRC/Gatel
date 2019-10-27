<template>
	<v-card>
		<v-card-title primary-title>Cliente - Editar</v-card-title>
		<v-divider></v-divider>
		<v-card-text>
			<v-form v-model="formIsValid" ref="form">
				<v-text-field :rules="[rules.required]" v-model="name" label="nome" required></v-text-field>
				<v-text-field readonly :rules="[rules.emailMatch]" v-model="email" label="E-mail" required></v-text-field>
				<v-text-field :rules="[rules.required]" v-model="apartament" label="Apartamento" required></v-text-field>
				<v-text-field
					:rules="[rules.required]"
					v-model="phone"
					v-mask="maskPhone"
					label="Celular"
					required
				></v-text-field>
				<v-switch v-model="isAdmin" label="Admin" type="checkbox"></v-switch>
			</v-form>
		</v-card-text>
		<v-divider></v-divider>
		<v-card-actions>
			<v-spacer></v-spacer>
			<v-btn @click="closeDialog()" small color="error">Cancelar</v-btn>
			<v-btn :disabled="!formIsValid" @click="editUser()" small color="success">
				Salvar
				<v-icon right dark>save</v-icon>
			</v-btn>
		</v-card-actions>
	</v-card>
</template>

<script>
import rules from "../../rules";

export default {
	data: () => {
		return {
			name: "",
			email: "",
			phone: "",
			apartament: "",
			isAdmin: false,
			maskPhone: "(##) #####-####",
			rules: rules,
			formIsValid: false
		};
	},
	methods: {
		closeDialog() {
			this.$emit("close");
		},
		editUser() {
			this.$emit("editUser", {
				name: this.name,
				apartament: this.apartament,
				phone: this.phone,
				isAdmin: this.isAdmin,
				id: this.userData.id
			});
		}
	},
	props: {
		userData: {
			required: true,
			type: Object
		}
	},
	created() {
		this.name = this.userData.name;
		this.email = this.userData.email.address;
		this.phone = this.userData.phone;
		this.apartament = this.userData.apartament;
		this.isAdmin = this.userData.isAdmin;
	}
};
</script>
