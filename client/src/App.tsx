import { List, ListItem, ListItemText, Typography } from "@mui/material";
import { useEffect, useState } from "react"
import axios from "axios"

function App() {

  const[activities,setActivities]=useState<Activity[]>([]);
  useEffect(() => {
    // fetch('https://localhost:5001/api/activities')
    axios.get<Activity[]>('https://localhost:5001/api/activities')
          .then(response => setActivities(response.data))

    return () => {}

  },[])
  return (
    <>

    
      {/* <h3 className="app" style={{color:'red'}}>Reactivities</h3> */}

       <Typography variant='h3'>Reactivities</Typography>
      <List>
        {activities.map((activity)=>(
          
          <ListItem key={activity.id}>
            <ListItemText>{activity.title}</ListItemText>
            
         
            </ListItem>
          
        ))}

      </List>

   </>
   
      
   
  )
}

export default App
