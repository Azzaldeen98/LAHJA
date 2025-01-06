window.reloadPage = function () {
    location.reload();
};


window.downloadAudioFromElement = (audioElementId, fileName) => {
    const audioElement = document.getElementById(audioElementId);

    if (audioElement && audioElement.currentSrc) {
        const linkElement = document.createElement('a');
        linkElement.href = audioElement.currentSrc;
        linkElement.download = fileName || 'audio-file.mp3';
        document.body.appendChild(linkElement);
        linkElement.click();
        document.body.removeChild(linkElement);
    } else {
        console.error("Audio source not found or invalid audio element.");
    }
};


function typeText(elementId, text, typingSpeed) {
    const container = document.getElementById(elementId);
    let i = 0;

    function type() {
        if (i < text.length) {
            container.innerHTML += text.charAt(i);
            i++;
            setTimeout(type, typingSpeed);
        }
    }

    container.innerHTML = ""; // ÊÝÑíÛ ÇáäÕ ÇáÓÇÈÞ
    type();
}


function controlSoundAnimation(isStart = false) {

    var animate = document.getElementById("logo-icon-animate-id");

    if (animate != null) {
        animate.style.display = (isStart) ? "flex !important" : "none !important";
    }

    var static = document.getElementById("logo-icon-static-id");

    if (static != null) {
        static.style.display = (!isStart) ? "block !important" : "none !important";
    }
}



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


//async function queryModelTextToSpeech2(data) {

//    alert(777)
//             data = JSON.parse(data);

//            if (!data) {
//                alert("Please enter some text");
//                return "333";
//            }

//            const audioData = await queryT2S(data);

//            // Create a URL for the audio Blob
//            const audioUrl = URL.createObjectURL(audioData);

//            // Get the audio player element and set the source
//    const audioPlayer = document.getElementById(data.TagId);
//            audioPlayer.src = audioUrl;

//            // Play the audio
//        audioPlayer.play();

//        return "222";
   
//    }

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



//async function queryModelTextToSpeech1(inputText) {

//    if (!inputText) {
//        alert("Please enter some text");
//        return "333";
//    }

//    const audioData = await queryT2S1(inputText);

//    // Create a URL for the audio Blob
//    const audioUrl = URL.createObjectURL(audioData);

//    // Get the audio player element and set the source
//    const audioPlayer = document.getElementById("OutputPlayerId");
//    audioPlayer.src = audioUrl;

//    // Play the audio
//    audioPlayer.play();

//}



//async function getEventIdAndData() {
//    // Make the first POST request to get the EVENT_ID
//    const response = await fetch('https://wasmdashai-lahja-ai.hf.space/call/predict', {
//        method: 'POST',
//        headers: {
//            'Content-Type': 'application/json',
//        },
//        body: JSON.stringify({
//            data: [
//                "Hello!!",
//                "wasmdashai/vits-ar-sa-huba-v1",
//                0
//            ]
//        })
//    });

//    // Parse the response and extract the EVENT_ID
//    const data = await response.json();
//    const eventId = data?.event_id || '';  // Extract the event ID if available

//    if (!eventId) {
//        console.error('EVENT_ID not found');
//        return;
//    }

//    // Make the second request to get the result using the EVENT_ID
//    const finalResponse = await fetch(`https://wasmdashai-lahja-ai.hf.space/call/predict/${eventId}`, {
//        method: 'GET'
//    });

//    // Parse and log the result
//    const result = await finalResponse.json();
//    console.log(result);
//}



   

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
window.playerAudioSource = (audioUrl, audioElementId = "audioPlayer") => {

    const audioElement = document.getElementById(audioElementId);
    audioElement.src = audioUrl;
    audioElement.play();
}
//function playerAudioSource(audioUrl) {

//    //const audioPlayer = document.getElementById("audioPlayer");
//    //audioPlayer.src = audioUrl;

//    //// Play the audio
//    //audioPlayer.play();

//    //fetch(audioUrl)
//    //    .then(response => {
//    //        if (!response.ok) throw new Error("Failed to fetch audio data");
//    //        return response.blob();
//    //    })
//    //    .then(blob => {
//            //const audioUrl = URL.createObjectURL(blob);
//            const audioElement = document.getElementById("audioPlayer");
//            audioElement.src = audioUrl;
//            audioElement.play();
//        //})
//        //.catch(error => {
//        //    console.error("Error:", error);
//        //});
//}
 function extractData(data) {
    // Split the data based on the keyword "data:"
    const parts = data.split('data: ');
    
    if (parts.length > 1) {
       
        const jsonData = JSON.parse(parts[1].trim());


                            const audioUrl = jsonData[0].url;

                            const audioPath = jsonData[0].path;
                            const originalName = jsonData[0].orig_name;


                            return {
                                audioUrl,
                                audioPath,
                                originalName
                            };
    } else {
        throw new Error("Data format incorrect.");
    }
}

//function convertTextToSpeech(text2) {

    ////data = JSON.parse(data);
    //var text = "ÇáÓáÇã Úáíßã";
    //if (!data) {
    //    alert("Please enter some text");
    //    return "333";
    //}
      

    //                        // Define the payload and headers
    //const payload = {
    //    data:
    //        [    text, // The text to convert to speech
    //            "wasmdashai/vits-ar-sa-huba-v2", // Model identifier
    //             0.6 // Speaker ID or variation
    //        ]
    //};

    //const headers = {
    //     "Content-Type": "application/json"
    //};

    //                        // Step 1: Send the POST request
    //      fetch("https://wasmdashai-runtasking.hf.space/call/predict", {
    //                         method: "POST",
    //                        headers: headers,
    //                        body: JSON.stringify(payload)
    //        }) .then(response => response.json())
    //            .then(data => {
    //                // Extract the EVENT_ID from the response
    //                const eventId = data.event_id; // Assuming the response format contains event ID here
    //                        console.log("Event ID:", eventId);

    //                        // Step 2: Use the EVENT_ID in the next request to fetch the audio file
    //                        return fetch(https://wasmdashai-runtasking.hf.space/call/predict/${eventId}, {
    //                            method: "GET"
    //                });
    //            })
    //            .then(response => {
    //                if (!response.ok) {
    //                    throw new Error("Failed to fetch audio data");
    //                }
    //                        // Parse the audio data as a Blob
    //                        return response.text();
    //            })
    //            .then(blob => {
    //                // Convert Blob to Object URL
    //                const extractedData = extractData(blob);
    //                        console.log(extractedData)

    //                        console.log("Event ID:",extractedData.audioUrl );

    //                        // Set the audio source to the Blob URL and play
    //                const audioElement = document.getElementById("audioPlayer");
    //                        audioElement.src ='https://wasmdashai-runtasking.hf.space/file='+extractedData.audioPath;
    //                        audioElement.play();
    //            })
    //            .catch(error => {
    //                            console.error("Error:", error);
    //            });

    //            return "222"
    //    }



function convertTextToSpeech() {


    alert("convertTextToSpeech")

 
    const text = "ÇáÓáÇã Úáíßã"; // ÇáäÕ ÇáÇÝÊÑÇÖí
    if (!text) {
        alert("Please enter some text");
        return "Input is required.";
    }

    // ÅÚÏÇÏ ÇáÈíÇäÇÊ ÇááÇÒãÉ
    const payload = {
        data: [
            text, // ÇáäÕ ÇáãÏÎá
            "wasmdashai/vits-ar-sa-huba-v2", // ãÚÑÝ ÇáäãæÐÌ
            0.6 // ID ÇáãÊÍÏË Ãæ ÇáÊäæíÚ
        ]
    };

    const headers = {
        "Content-Type": "application/json"
    };

    // ÇáÎØæÉ 1: ÅÑÓÇá ÇáØáÈ ÇáÃæá
    fetch("https://wasmdashai-runtasking.hf.space/call/predict", {
        method: "POST",
        headers: headers,
        body: JSON.stringify(payload)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error("Failed to send POST request");
            }
            return response.json();
        })
        .then(data => {
            const eventId = data.event_id; // ÇÓÊÎÑÇÌ event_id ãä ÇáÇÓÊÌÇÈÉ
            console.log("Event ID:", eventId);

            // ÇáÎØæÉ 2: ÅÑÓÇá ÇáØáÈ ÇáËÇäí ááÍÕæá Úáì ÇáãáÝ ÇáÕæÊí
            return fetch(`https://wasmdashai-runtasking.hf.space/call/predict/${eventId}`, {
                method: "GET"
            });
        })
        .then(response => {
            if (!response.ok) {
                throw new Error("Failed to fetch audio data");
            }
            return response.json(); // ÊÍæíá ÇáÇÓÊÌÇÈÉ Åáì JSON
        })
        .then(data => {

            console.log("dataL:", data);
            // ÇáÊÃßÏ ãä ÇáÈíÇäÇÊ ÇáãÓÊáãÉ
            const audioUrl = data.audioPath; // ÊÃßÏ ãä ÊäÓíÞ ÇáÈíÇäÇÊ Ýí ÇáÇÓÊÌÇÈÉ
            if (!audioUrl) {
                throw new Error("Audio URL not found in response");
            }

        
            console.log("Audio URL:", audioUrl);

            // ÊÔÛíá ÇáãáÝ ÇáÕæÊí
            const audioElement = document.getElementById("audioPlayer");
            if (audioElement) {
                audioElement.src = `https://wasmdashai-runtasking.hf.space/file=${audioUrl}`;
                audioElement.play();
            } else {
                console.error("Audio element not found in the DOM");
            }
        })
        .catch(error => {
            console.error("Error:", error);
        });

    return "222";
}
