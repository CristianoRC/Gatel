<template>
	<v-card>
		<v-card-title primary-title>Veículo</v-card-title>
		<v-divider></v-divider>
		<v-card-text>
			<v-flex xs12>
				<center>
					<img :src="manufacturerImage" width="50%" />
				</center>
			</v-flex>
			<v-form v-model="formIsValid" ref="form">
				<v-text-field
					:rules="[rules.required, rules.plate]"
					v-model="plate"
					label="Placa"
					v-mask="maskPlate"
					required
				></v-text-field>
				<v-select
					:rules="[rules.required]"
					:items="manufacturers"
					v-model="manufacturer"
					label="Fabricante"
				></v-select>
				<v-text-field :rules="[rules.required]" v-model="model" label="Modelo" required></v-text-field>
				<v-select :rules="[rules.required]" :items="colors" v-model="color" label="Cor"></v-select>
			</v-form>
		</v-card-text>
		<v-divider></v-divider>
		<v-card-actions>
			<v-spacer></v-spacer>
			<v-btn @click="closeDialog()" small color="error">Cancelar</v-btn>
			<v-btn :disabled="!formIsValid" @click="editVehicle()" small color="success">
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
			plate: "",
			color: "",
			model: "",
			manufacturer: "Audi",
			maskPlate: "AAA-####",
			rules: rules,
			formIsValid: false,
			colors: [
				"Branco",
				"Prata",
				"Preto",
				"Cinza",
				"Vermelho",
				"Azul",
				"Outra"
			],
			manufacturers: [
				"Audi",
				"BMW",
				"Chevrolet",
				"Citroen",
				"Fiat",
				"Ford",
				"Honda",
				"Hyundai",
				"Jeep",
				"Mercedes-Benz",
				"Mitsubishi",
				"Nissan",
				"Peugeot",
				"Renault",
				"Peugeot",
				"Volkswagen"
			]
		};
	},
	methods: {
		closeDialog() {
			this.$emit("close");
		},
		editVehicle() {
			this.$emit("editVehicle", {
				plate: this.plate,
				color: this.color,
				model: this.model,
				manufacturer: this.manufacturer
			});
		}
	},
	computed: {
		manufacturerImage() {
			return `https://static.kbb.com.br/Themes/GPS/Images/pt_BR/Brands/${this.manufacturer}.png`;
		}
	},
	props: {
		vehicleData: {
			required: true,
			type: Object
		}
	},
	created() {
		const vehicleData = JSON.parse(JSON.stringify(this.vehicleData));
		this.plate = vehicleData.plate.value;
		this.color = vehicleData.color;
		this.model = vehicleData.model;
		this.manufacturer = vehicleData.manufacturer;
	}
};
</script>
