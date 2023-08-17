<template>
  <v-row>
    <v-col cols="2" md="6">
      <v-form ref="form">
        <v-text-field v-model="conversation.title"
                      :rules="[required]"
                      :readonly="loading"
                      label="Title"></v-text-field>

        <v-select v-model="conversation.prompt"
                  v-if="!id"
                  :items="promptItems"
                  :readonly="loading"
                  item-value="id"
                  item-text="title"
                  label="Prompt"
                  clearable
                  return-object
                  single-line></v-select>

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
      },
      prompts:{
        type: Array,
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

        if (!valid)
          return;

        try {
          this.loading = true;
          if (this.id)
            await this.update();
          else
            await this.add();
        } catch (e) {
          console.error(e);
        }
        finally{
          this.loading = false;
        }
      },
      async add(){
        var payload = {
          title: this.conversation.title,
          promptId: this.conversation.prompt?.id
        };
        console.log("payload:", this.payload);
        await this.$axios.post('api/Conversations', payload)
          .then((res) => {
              this.$router.push("/conversations");
          })
          .catch((error) => {
              console.error('error:', error);
          });
      },
      async update(){
        var payload = {
          title: this.conversation.title
        };
        await this.$axios.put('api/Conversations/' + this.id, payload)
          .then((res) => {
              this.$router.push("/conversations");
          })
          .catch((error) => {
              console.error('error:', error);
          });
      }

    },
}
</script>
