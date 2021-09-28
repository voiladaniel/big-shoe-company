import './App.css';
import { FileUpload } from './Components/FileUpload';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
  return (
    <>
      <div>
        <header className="App-header no-printme">
          <h1 className="company-header">Big Shoe Company</h1>
          <br/>
        </header>
      </div>      
      <div className="App">
        <FileUpload />
      </div>
    </>
  );
}

export default App;
