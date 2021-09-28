import React, { useState } from 'react';
import {useDropzone} from 'react-dropzone';
import axios from "axios";
import { Button } from 'react-bootstrap'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faBolt, faPrint } from '@fortawesome/free-solid-svg-icons'
import { Orders } from './Orders';

export const FileUpload = () => {
  const [errorValidation, setError] = useState(false);
  const [netowrkError, setNetworkError] = useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const [printAvailable, setPrintAvailable] = useState(false);
  const [processedOrders, setProcessedOrders] = useState([]);

  const {acceptedFiles, getRootProps, getInputProps} = useDropzone({ 
    accept: 'text/xml'
  });
  
  const files = acceptedFiles.map(file => (
    <div key={file.path} className="fileText">
      {file.path}
    </div>
  ));

  let formData = new FormData()
  
  acceptedFiles.map((file) => (
    formData.append("formFile", file),
    formData.append("fileName", file.name)
  ));

  const uploadFile = async (e) => {
    e.preventDefault();
    setIsLoading(true);
    try {
      const res = await axios.post(process.env.REACT_APP_PROCESS_XML_API, formData)
      .then(function (response) {
        setProcessedOrders(response.data);
        setError(false);
        setPrintAvailable(true);
        setIsLoading(false);
        setNetworkError(false);
      })
      .catch(function(error) {
        if (!error.status) {
            try{
                if(error.message.includes("Network Error") )
                {
                  console.log("Network error!")
                  setProcessedOrders([]);
                  setNetworkError(true);
                  setError(error);
                  setPrintAvailable(false);
                  setIsLoading(false);
                }
                else{
                  setProcessedOrders([]);
                  setNetworkError(false);
                  setError(error);
                  setPrintAvailable(false);
                  setIsLoading(false);
                }  
            }
            catch{
                setProcessedOrders([]);
                setError(error);
                setPrintAvailable(false);
                setIsLoading(false);
                setNetworkError(false);
            }
        }
      });
      console.log(res);
    } catch (ex) {
      console.log(ex);
    }
  };

  return (
    <section className="container">
      <div {...getRootProps({className: 'dropzone use-pointer no-printme'})}>
        <input {...getInputProps()} />
        <p>Drag 'n' drop Order xml file here, or click to select file</p>
      </div>
      <aside className="no-printme grey-font-color">
        <br/>
        <h4>File selected:</h4>
        <ul>{files}</ul>
      </aside>
      <aside className="no-printme">
        <Button variant="warning" onClick={uploadFile} className="use-pointer" disabled={!files.length > 0}> 
          <FontAwesomeIcon icon={faBolt} />
          &nbsp;
          Process Custom Order
        </Button>
        <Button variant="warning" className="use-pointer margin-left-20 no-printme" onClick={() => window.print()} hidden={!printAvailable}>
        &nbsp;
        <FontAwesomeIcon icon={faPrint} />
          &nbsp;
          Print Orders
        </Button>
      </aside>
      <Orders processedOrders={processedOrders} errorValidation={errorValidation} isLoading={isLoading} networkError={netowrkError}/>
    </section>
  );
}
