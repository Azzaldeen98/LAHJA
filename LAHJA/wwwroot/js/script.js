
  async function queryT2S(data) {
        const response = await fetch(
            data.Url, 
            {
                headers: data.Headers,
                method: data.Method,
                body: JSON.stringify(data.Data),
            }
        );
        const result = await response.blob(); // Returns a blob containing the audio data
        return result;
    }

async function queryModelTextToSpeech(data) {

             data = JSON.parse(data);

            if (!data) {
                alert("Please enter some text");
                return "333";
            }

            const audioData = await queryT2S(data);

            // Create a URL for the audio Blob
            const audioUrl = URL.createObjectURL(audioData);

            // Get the audio player element and set the source
    const audioPlayer = document.getElementById(data.TagId);
            audioPlayer.src = audioUrl;

            // Play the audio
        audioPlayer.play();

        return "222";
   
    }

async function queryT2S1(inputText) {

    const response = await fetch(
        "https://api-inference.huggingface.co/models/wasmdashai/vits-ar-sa-huba-v2",
        {
            headers: {
                Authorization: "Bearer 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", // Replace with your actual API token
                "Content-Type": "application/json",
            },
            method: "POST",
            body: JSON.stringify(inputText),
        }
    );
    const result = await response.blob(); // Returns a blob containing the audio data
    return result;
}



async function queryModelTextToSpeech1(inputText) {

    if (!inputText) {
        alert("Please enter some text");
        return "333";
    }

    const audioData = await queryT2S1(inputText);

    // Create a URL for the audio Blob
    const audioUrl = URL.createObjectURL(audioData);

    // Get the audio player element and set the source
    const audioPlayer = document.getElementById("OutputPlayerId");
    audioPlayer.src = audioUrl;

    // Play the audio
    audioPlayer.play();

}
