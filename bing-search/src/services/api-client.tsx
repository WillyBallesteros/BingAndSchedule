import axios from 'axios';

export default axios.create({
  baseURL: 'https://api.bing.microsoft.com/v7.0',
  headers: {
    'Ocp-Apim-Subscription-Key': 'cc41afcd8a1744dab2e9fa3a8a0ed9ca'
  }
})