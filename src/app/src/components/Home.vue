<template>
	<v-container>
		<v-layout text-center wrap>
			<v-flex xs12>{{plate}}</v-flex>
			<v-flex xs12>
				<vue-web-cam
					:device-id="deviceId"
					ref="webcam"
					@camera-change="onCameraChange"
					@cameras="onCameras"
					@error="onError"
					height="500px"
					width="500px"
				/>
			</v-flex>
			<!-- Controle -->
			<v-flex xs4>
				<v-btn @click="capture" color="success">Capturar</v-btn>
			</v-flex>
			<v-flex xs4>
				<v-btn @click="stopWebcam" color="danger">Parar</v-btn>
			</v-flex>
			<v-flex xs4>
				<v-btn @click="startWebcam" color="info">Iniciar</v-btn>
			</v-flex>
			<!-- Escolha da câmera -->
			<v-flex xs12>
				<v-select
					:items="devices"
					v-model="camera"
					item-text="label"
					item-value="deviceId"
					label="Escolha a câmera"
				></v-select>
			</v-flex>
			<v-flex xs12>
				<img width="100px" :src="image" alt />
			</v-flex>
		</v-layout>
	</v-container>
</template>

<script>
import { WebCam } from "vue-web-cam";
import urls from "../urls";

export default {
	components: {
		"vue-web-cam": WebCam
	},
	data: () => {
		return {
			image: null,
			camera: null,
			deviceId: null,
			defaultImageData: "data:,",
			plate: "",
			devices: []
		};
	},
	methods: {
		capture() {
			if (this.$refs.webcam != undefined) {
				this.image = this.$refs.webcam.capture();
			}
			return this.image;
		},
		startWebcam() {
			this.$refs.webcam.start();
		},
		stopWebcam() {
			this.$refs.webcam.stop();
		},
		onError(error) {
			console.error(error);
		},
		onCameraChange(deviceId) {
			this.deviceId = deviceId;
			this.camera = deviceId;
		},
		onCameras(cameras) {
			this.devices = cameras;
		},
		capturewithInterval(interval) {
			setInterval(() => {
				this.capture();
			}, interval);
		}
	},
	watch: {
		camera(id) {
			this.deviceId = id;
		},
		devices() {
			const [first, ...tail] = this.devices;
			if (first) {
				this.camera = first.deviceId;
				this.deviceId = first.deviceId;
			}
		},
		async image(val) {
			if (val !== this.defaultImageData) {
				val = val.replace(/^data:image.+;base64,/, "");

				const response = await this.$http.post(
					urls.acessControll.verifyVehicle,
					{ Image: val }
				);
				console.log(response.data);
			}
		}
	},
	created() {}
	// this.capturewithInterval(2500);
};
</script>
