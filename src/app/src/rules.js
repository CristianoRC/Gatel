export default {
  required: value => !!value || 'Obrigatório.',
  min: v => v.length >= 8 || 'No mínimo 8 caracteres',
  emailMatch: (v) => {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(v).toLowerCase()) || 'Email inválido'
  }

}