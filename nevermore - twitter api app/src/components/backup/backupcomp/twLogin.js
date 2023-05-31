import React, { Component } from "react"
import firebase from "firebase"
import StyledFirebaseAuth from "react-firebaseui/StyledFirebaseAuth"




firebase.initializeApp({
  apiKey: "AIzaSyDgr2OkT8Q4rZkHMR_hM0YnVvvEbeQX8tA",
  authDomain: "nevermore-291718.firebaseapp.com",
  databaseURL: "https://nevermore-291718.firebaseio.com",
  projectId: "nevermore-291718",
  storageBucket: "nevermore-291718.appspot.com",
  messagingSenderId: "624571026046",
  appId: "1:624571026046:web:f8ccb46afe841d4249262f"
})


var postUrl;
var tweetText;

function createUrl(tweetText) {
  tweetText.replace(" ", "%20");
  tweetText.replace("#", "%23");
  postUrl = postUrl + tweetText;
  return postUrl;
}

class twLogin extends Component {
  state = { isSignedIn: false }
  uiConfig = {
    signInFlow: "popup",
    signInOptions: [
      firebase.auth.TwitterAuthProvider.PROVIDER_ID,
    ],
    callbacks: {
      signInSuccessWithAuthResult: function (result) {
        var token = result.credential.accessToken;
        var secret = result.credential.secret;
        console.log("Access token: ", token, "\n", "Token secret", secret)
        //alert("token: " +  token + "\n" + "secret: " + secret)
        postUrl = "https://us-west2-nevermore-291718.cloudfunctions.net/functionpython-2?acctoken=" + token + "&toksecret=" + secret + "&tbody=Sent%20by%20Nevermore%20%23Nevermoretweet";
      }
    }
  }

  constructor(props) {
    super(props);
    this.tweetthis = React.createRef();
  }

  tweetthis() {
    var functions = firebase.app().functions('europe-west1');
    var callTweet = firebase.functions().httpsCallable('functionpython-2')
    callTweet().then(result => (
      console.log(result.data)
    ))
  }

  componentDidMount = () => {
    firebase.auth().onAuthStateChanged(user => {
      this.setState({ isSignedIn: !!user })
      console.log("user", user)
    }
    )
  }
  render = () => {
    return (
      <div className="App">
        <div>Hello, Welcome to Nevermore</div>
        {this.state.isSignedIn ? (
          <span>
            <div>Signed In!</div>
            <h1>Welcome {firebase.auth().currentUser.displayName}</h1>
            <img
              alt="profile pic"
              src={firebase.auth().currentUser.photoURL}
            />
            <p>
              <textarea name="screech" rows="5" id="screech" ></textarea>
            </p>
            <p>
              <button id="tweet" ref={this.tweetthis}>Post tweet</button>

            </p>
            <p>
              <button onClick={() => firebase.auth().signOut()}>Sign out</button>
            </p>


          </span>
        ) : (
            <StyledFirebaseAuth
              uiConfig={this.uiConfig}
              firebaseAuth={firebase.auth()}
            />
          )}
      </div>
      
      
      
    )
  }
}

export default twLogin
