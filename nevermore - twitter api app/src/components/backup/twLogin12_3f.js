import React, { Component } from "react"
import firebase from "firebase"
import StyledFirebaseAuth from "react-firebaseui/StyledFirebaseAuth"
​
​
​
firebase.initializeApp({
  apiKey: "",
  authDomain: "nevermore-291718.firebaseapp.com"
})
var postUrl;
var tbody;
​
function createUrl(tweetText){
  tweetText.replace(" ", "%20");
  tweetText.replace("#","%23");
  postUrl = postUrl + tweetText;
  return postUrl;
}
​
class twLogin extends Component {
  state = { isSignedIn: false }
  uiConfig = {
    signInFlow: "popup",
    signInOptions: [
      firebase.auth.TwitterAuthProvider.PROVIDER_ID,
    ],
    callbacks: {
      signInSuccessWithAuthResult: function(result){
        var token = result.credential.accessToken;
        var secret = result.credential.secret;
        console.log("Access token: ", token , "\n" , "Token secret", secret)
        //alert("token: " +  token + "\n" + "secret: " + secret)
        postUrl = "https://us-west2-nevermore-291718.cloudfunctions.net/function-2?acc_token=" +  token + "&token_secret=" + secret + "&tbody=";
      }
    }
  }
​
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
            <button onClick={() => firebase.auth().signOut()}>Sign out!</button>
            <h1>Welcome {firebase.auth().currentUser.displayName}</h1>
            <img
              alt="profile pic"
              src={firebase.auth().currentUser.photoURL}
            />
            <p>
            <textarea name="screech" rows="5" id="screech" ></textarea>
            </p>
            <p>
            <button id="tweet">Submit</button>
​
              <script>
                $(document).ready(function(){
                    $("tweet").click(function(){
                      var comment = $.trim($("#screech").val());
                      if(comment != ""){
                        // Show alert dialog if value is not blank
                        window.location = createUrl(comment);
                      }
                    });
        
                });
              </script>
​
            </p>
            
​
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
​
export default twLogin
