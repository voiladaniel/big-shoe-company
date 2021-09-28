
import Loader from 'react-loader-spinner';

export const Orders = ({ processedOrders, errorValidation, isLoading, networkError }) => {
    return(<>
    {isLoading ?
        <Loader type="ThreeDots" color="#db3d44" height={100} width={100} /> :
        networkError ?
        <>
            <br/>
            <h4 className="red-font-color">Newtwork error! Please make sure the service is up and ruunning!</h4>
        </> :
        <> { processedOrders.length?
            processedOrders.map((orders, index) => (
              <div className="row printme" key={index}>
                <div className={"col-lg-12 col-md-12 text-center custom-div-template use-pointer " + (!orders.hasDateError  ? "green-background" : "red-background")} onClick={() => console.log("da")}>
                      <div>
                        <h6>
                            Customer Name: {orders.customerName} <br/>
                            Customer Email: {orders.customerEmail} <br/>
                            Date Required: {orders.dateRequired} <br/>
                            Notes: {orders.notes} <br/>
                            Quantity: {orders.quantity} <br/>  
                            Size: {orders.size} <br/>
                        </h6>
                        {orders.hasDateError  ? 
                        <>
                            <br/>
                            <h2>Please enter a valid date!</h2>
                        </> : <></>}
                      </div>
                  </div>
              </div>
            )) : <></>
          }
           { errorValidation?
              <div className="row no-printme">
                <div className={"col-lg-12 col-md-12 text-center custom-div-template use-pointer red-background"}>
                    <div>
                        <br/>
                        <h2>Validation Error! Please make sure you follow the guideline:</h2>
                        <h6>
                          Customer Name must be provided <br/>
                          Customer Email must be a valid email address <br/>
                          Date must be valid and at least 10 working days into the future <br/>
                          Size must be 11.5 to 15 including half sizes <br/>
                          Quantity must be in multiples of 1000 <br/>
                        </h6>
                    </div>
                  </div>
              </div>
             : <></>
          }
          </>
        }
    </>)
};