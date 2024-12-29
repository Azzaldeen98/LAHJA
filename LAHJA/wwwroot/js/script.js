
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



async function getEventIdAndData() {
    // Make the first POST request to get the EVENT_ID
    const response = await fetch('https://wasmdashai-lahja-ai.hf.space/call/predict', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            data: [
                "Hello!!",
                "wasmdashai/vits-ar-sa-huba-v1",
                0
            ]
        })
    });

    // Parse the response and extract the EVENT_ID
    const data = await response.json();
    const eventId = data?.event_id || '';  // Extract the event ID if available

    if (!eventId) {
        console.error('EVENT_ID not found');
        return;
    }

    // Make the second request to get the result using the EVENT_ID
    const finalResponse = await fetch(`https://wasmdashai-lahja-ai.hf.space/call/predict/${eventId}`, {
        method: 'GET'
    });

    // Parse and log the result
    const result = await finalResponse.json();
    console.log(result);
}





//import { Client } from "https://cdn.jsdelivr.net/npm/@gradio/client/dist/index.min.js"; // ÊÍãíá ãßÊÈÉ Gradio ãä CDN

//async function Text2Text(data) {

//    try {

//        data = JSON.parse(data);

//        const client1 = await Client.connect(data.Space);
//        const result = await client1.predict(data.Function, {
//            text: data.Input,
//            key: data.Key,
//        });

//        const textres = result.data;

//        return textres;
//    } catch {
//        return null;
//    }

//}

//async function Text2Speech(data) {

//    try {
//        // ÇáÇÊÕÇá ÈÜ Gradio API
//        data = JSON.parse(data);

//        const client = await Client.connect(data.Space);
//        const result = await client.predict(data.Function, {
//            text: data.Input,
//            name_model: data.Model,
//            speaking_rate: data.SR,
//        });




//        const audioPlayer = document.getElementById(data.AudioPlayerID);
//        if (result.data) {
//            audioPlayer.src = result.data[0].url; // ÊÚííä ÑÇÈØ ÇáÕæÊ
//            audioPlayer.style.display = 'block'; // ÅÙåÇÑ ãÔÛá ÇáÕæÊ
//            audioPlayer.play(); // ÊÔÛíá ÇáÕæÊ ÊáÞÇÆíðÇ
//        }
//        return "222"
//    } catch (error) {

//        return "333.3"
//    }
//}
//async function VoiceBot(data) {

//    alert(data)
//    data = JSON.parse(data);
//    alert(data)
//    var text = Text2Text(data.Text2Text)
//    if (text != null) {
//        data.Speech.Input = text;

//        var res = Text2Speech(data.Speech)
//        return res
//    }

//    return "333.3"

//}
async function t2t(data) {
    //const url = 'https://wasmdashai-t2t.hf.space/gradio_api/call/predict';

    data = JSON.parse(data);

    try {
        // Step 1: POST request to get EVENT_ID
        const postResponse = await fetch(data.URL, {
            method: data.Method,
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                data: [data.Text, data.Key],
            }),
        });

        const postData = await postResponse.json();
        const eventId = postData?.event_id;





        const getResponse = await fetch(`${data.URL}/${eventId}`, {
            method: 'GET',
        });

        const reader = getResponse.body.getReader();
        const decoder = new TextDecoder('utf-8');
        let result = '';

        while (true) {
            const { done, value } = await reader.read();
            if (done) break;
            result += decoder.decode(value);
        }

        const dataLine = result.split('\n').find(line => line.startsWith('data:'));
        const jsonString = dataLine.replace('data: ', '');

        return jsonString;
    } catch (error) {

        return null;
    }
}
//async function t2t(data) {

//    alert("Alert")
//    const url = 'https://wasmdashai-t2t.hf.space/gradio_api/call/predict';



//    try {

//        data = JSON.parse(data);
//        // Step 1: POST request to get EVENT_ID
//        const postResponse = await fetch(data.URL, {
//            method: data.Method,
//            headers: {
//                'Content-Type': 'application/json',
//            },
//            body: JSON.stringify({
//                data: [data.Text, data.Key],
//            }),
//        });

//        const postData = await postResponse.json();
//        const eventId = postData?.event_id;
        




//        const getResponse = await fetch(`${ data.URL } / ${ eventId }`, {
//            method: 'GET',
//        });
        
        
//        const reader = getResponse.body.getReader();
//        const decoder = new TextDecoder('utf-8');
//        let result = '';
        
//        while (true) {
//            const { done, value } = await reader.read();
//            if (done) break;
//            result += decoder.decode(value);
//        }
//        alert('jsonString')
//        const dataLine = result.split('\n').find(line => line.startsWith('data:'));
//        const jsonString = dataLine.replace('data: ', '');
        
//        return jsonString[0];
//    } catch (error) {

//        return null;
//    }
//}
