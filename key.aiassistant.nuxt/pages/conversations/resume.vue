<template>
  <v-row>
    <v-col cols="2" md="6">
      <v-form ref="form">
        <v-textarea
          v-model="vacancy"
          filled
          counter
          rows="8"
          label="Vacancy"
          hint="Paste text of the vacancy here"
          :readonly="loading"
        />

        <v-textarea
          v-model="resume"
          filled
          counter
          rows="8"
          label="Resume"
          hint="Paste text of your resume here"
          :readonly="loading"
        />

        <div class="d-flex flex-column">
          <v-btn
            color="success"
            class="mt-4"
            block
            @click.prevent="submitForm"
          >
            Submit
          </v-btn>
        </div>
      </v-form>
    </v-col>
  </v-row>
</template>

<script>

export default {
  name: 'NewResumePage',
  data () {
    return {
      vacancy: null,
      resume: null,
      prompts: [],
      loading: false
    }
  },
  methods: {
    async submitForm () {
      const valid = await this.$refs.form.validate()

      if (!valid) { return }

      try {
        this.loading = true
        await this.add()
      } finally {
        this.loading = false
      }
    },
    async add () {
      const payload = {
        resume: this.resume,
        vacancy: this.vacancy
      }
      await this.$axios.post('api/Conversations/optimize-resume', payload)
        .then(() => {
          this.$router.push('/conversations')
        })
    }
  }

}
</script>
