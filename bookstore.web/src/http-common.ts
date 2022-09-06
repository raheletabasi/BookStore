import axios from "axios";
export default axios.create({
    baseURL: "https://localhost:7233",
    headers: {
        "Content-type": "application/json"
    }
});