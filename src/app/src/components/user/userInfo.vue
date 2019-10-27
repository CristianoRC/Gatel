<template>
	<v-card>
		<v-card-title primary-title>Cliente</v-card-title>
		<v-divider></v-divider>
		<v-card-text>
			<v-form v-model="formIsValid" ref="form">
				<v-text-field :rules="[rules.required]" v-model="name" label="nome" required></v-text-field>
				<v-text-field :rules="[rules.emailMatch]" v-model="email" label="E-mail" required></v-text-field>
				<v-text-field :rules="[rules.required]" v-model="apartament" label="Apartamento" required></v-text-field>
				<v-text-field
					:rules="[rules.required]"
					v-model="phone"
					v-mask="maskPhone"
					label="Celular"
					required
				></v-text-field>
				<v-text-field
					:rules="[rules.required, rules.min]"
					v-model="password"
					label="Senha inicial"
					required
				></v-text-field>
				<v-checkbox v-model="isAdmin" value="1" label="Admin" type="checkbox"></v-checkbox>
			</v-form>
		</v-card-text>
		<v-divider></v-divider>
		<v-card-actions>
			<v-spacer></v-spacer>
			<v-btn @click="closeDialog()" small color="error">Cancelar</v-btn>
			<v-btn :disabled="!formIsValid" @click="createUser()" small color="success">
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
			password: "",
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
		createUser() {
			this.$emit("createUser", {
				name: this.name,
				email: this.email,
				passWord: this.password,
				apartament: this.apartament,
				phone: this.phone,
				isAdmin: false
			});
		}
	}
};
</script>
