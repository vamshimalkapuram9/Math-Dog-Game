using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;
using UnityEngine;

public class SampleTable : MonoBehaviour
{

    static string tableName = "Usernames";
    static string partitionKey = "John";
    static string rowKey = "SubIntermediate";

    CloudTable table1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Table start called");
        makeConnection();
        _ =  InsertTableEntity(table1);
      
    }

    void makeConnection()
    {
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Tags.TABLE_CONN_URL);
        CloudTableClient tbClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());

         table1 = tbClient.GetTableReference(tableName);
        Console.ReadKey();
    }

    public static async Task<string> InsertTableEntity(CloudTable p_tbl)
    {
        User entity = new User(partitionKey, rowKey);
        
        TableOperation insertOperation = TableOperation.InsertOrMerge((ITableEntity)entity);
        TableResult result = await p_tbl.ExecuteAsync(insertOperation);
        Debug.Log("User Added");
        return "Employee added";
    }
}

class User
{
    string userName;
    string sceneName;

    public User(string userName, string sceneName)
    {
        this.userName = userName;
        this.sceneName = sceneName;
    }
}
