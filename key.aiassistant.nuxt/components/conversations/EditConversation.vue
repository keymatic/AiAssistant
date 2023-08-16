<template>
  <v-row>
    <v-col cols="2" md="6">
      <v-form ref="form">
        <v-text-field v-model="conversation.title"
                      :rules="[required]"
                      :readonly="loading"
                      label="Title"></v-text-field>

        <div class="d-flex flex-column">
          <v-btn color="success"
                 class="mt-4"
                 block
                 @click.prevent="submitForm">
            Submit
          </v-btn>
        </div>
      </v-form>
    </v-col>
  </v-row>
</template>

<script>
  export default {
    props: {
      id: {
        type:Number,
        required: false
      },
      title: {
        type: String,
        required: false
      },
      prompt: {
        type: Object,
        required: false
      }
    },
    data() {
      return {
        loading: false,
        conversation: {
          title: this.title,
          prompt: this.prompt,
        },
        promptItems:this.prompts
      }
    },
    methods: {
      required (v) {
        return !!v || 'Field is required'
      },
      async submitForm(){
        const valid = await this.$refs.form.validate();
        console.log("valid:", valid);

        if (!valid)
          return;

        try {
          this.loading = true;
          await this.update();
        } catch (e) {
          console.error(e);
        }
        finally{
          this.loading = false;
        }
      },
      async update(){
        var payload = {
          title: this.conversation.title
        };
        console.log("payload:", this.payload);

        await this.$axios.put('api/Conversations/' + this.id, payload)
          .then((res) => {
              console.log('success:', res);
              this.$router.push("/conversations");
          })
          .catch((error) => {
              console.log('error:', error);
          });
      }

    },
}
</script>
