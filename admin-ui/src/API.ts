/* tslint:disable */
/* eslint-disable */
//  This file was automatically generated and should not be edited.

export type CreateAssetInput = {
  id: string,
  title: string,
  type: AssetFileFormat,
  fileFormat: string,
  fileName: string,
  fileSize: string,
  file: S3ObjectInput,
  description?: string | null,
};

export enum AssetFileFormat {
  GLTF = "GLTF",
  GLB = "GLB",
  OBJ = "OBJ",
  FBX = "FBX",
}


export type S3ObjectInput = {
  bucket: string,
  key: string,
  region: string,
  localUri?: string | null,
  mimeType?: string | null,
  url?: string | null,
  _url?: string | null,
};

export type ModelAssetConditionInput = {
  title?: ModelStringInput | null,
  type?: ModelAssetFileFormatInput | null,
  fileFormat?: ModelStringInput | null,
  fileName?: ModelStringInput | null,
  fileSize?: ModelStringInput | null,
  description?: ModelStringInput | null,
  and?: Array< ModelAssetConditionInput | null > | null,
  or?: Array< ModelAssetConditionInput | null > | null,
  not?: ModelAssetConditionInput | null,
};

export type ModelStringInput = {
  ne?: string | null,
  eq?: string | null,
  le?: string | null,
  lt?: string | null,
  ge?: string | null,
  gt?: string | null,
  contains?: string | null,
  notContains?: string | null,
  between?: Array< string | null > | null,
  beginsWith?: string | null,
  attributeExists?: boolean | null,
  attributeType?: ModelAttributeTypes | null,
  size?: ModelSizeInput | null,
};

export enum ModelAttributeTypes {
  binary = "binary",
  binarySet = "binarySet",
  bool = "bool",
  list = "list",
  map = "map",
  number = "number",
  numberSet = "numberSet",
  string = "string",
  stringSet = "stringSet",
  _null = "_null",
}


export type ModelSizeInput = {
  ne?: number | null,
  eq?: number | null,
  le?: number | null,
  lt?: number | null,
  ge?: number | null,
  gt?: number | null,
  between?: Array< number | null > | null,
};

export type ModelAssetFileFormatInput = {
  eq?: AssetFileFormat | null,
  ne?: AssetFileFormat | null,
};

export type Asset = {
  __typename: "Asset",
  id: string,
  title: string,
  type: AssetFileFormat,
  fileFormat: string,
  fileName: string,
  fileSize: string,
  file: S3Object,
  description?: string | null,
  createdAt: string,
  updatedAt: string,
};

export type S3Object = {
  __typename: "S3Object",
  bucket: string,
  key: string,
  region: string,
};

export type UpdateAssetInput = {
  id: string,
  title?: string | null,
  type?: AssetFileFormat | null,
  fileFormat?: string | null,
  fileName?: string | null,
  fileSize?: string | null,
  file?: S3ObjectInput | null,
  description?: string | null,
};

export type DeleteAssetInput = {
  id: string,
};

export type CreateTodoInput = {
  id?: string | null,
  name: string,
  description?: string | null,
  image?: S3ObjectInput | null,
};

export type ModelTodoConditionInput = {
  name?: ModelStringInput | null,
  description?: ModelStringInput | null,
  and?: Array< ModelTodoConditionInput | null > | null,
  or?: Array< ModelTodoConditionInput | null > | null,
  not?: ModelTodoConditionInput | null,
};

export type Todo = {
  __typename: "Todo",
  id: string,
  name: string,
  description?: string | null,
  image?: S3Object | null,
  createdAt: string,
  updatedAt: string,
  owner?: string | null,
};

export type UpdateTodoInput = {
  id: string,
  name?: string | null,
  description?: string | null,
  image?: S3ObjectInput | null,
};

export type DeleteTodoInput = {
  id: string,
};

export type ModelAssetFilterInput = {
  id?: ModelIDInput | null,
  title?: ModelStringInput | null,
  type?: ModelAssetFileFormatInput | null,
  fileFormat?: ModelStringInput | null,
  fileName?: ModelStringInput | null,
  fileSize?: ModelStringInput | null,
  description?: ModelStringInput | null,
  and?: Array< ModelAssetFilterInput | null > | null,
  or?: Array< ModelAssetFilterInput | null > | null,
  not?: ModelAssetFilterInput | null,
};

export type ModelIDInput = {
  ne?: string | null,
  eq?: string | null,
  le?: string | null,
  lt?: string | null,
  ge?: string | null,
  gt?: string | null,
  contains?: string | null,
  notContains?: string | null,
  between?: Array< string | null > | null,
  beginsWith?: string | null,
  attributeExists?: boolean | null,
  attributeType?: ModelAttributeTypes | null,
  size?: ModelSizeInput | null,
};

export type ModelAssetConnection = {
  __typename: "ModelAssetConnection",
  items?:  Array<Asset | null > | null,
  nextToken?: string | null,
};

export type ModelTodoFilterInput = {
  id?: ModelIDInput | null,
  name?: ModelStringInput | null,
  description?: ModelStringInput | null,
  and?: Array< ModelTodoFilterInput | null > | null,
  or?: Array< ModelTodoFilterInput | null > | null,
  not?: ModelTodoFilterInput | null,
};

export type ModelTodoConnection = {
  __typename: "ModelTodoConnection",
  items?:  Array<Todo | null > | null,
  nextToken?: string | null,
};

export type CreateAssetMutationVariables = {
  input: CreateAssetInput,
  condition?: ModelAssetConditionInput | null,
};

export type CreateAssetMutation = {
  createAsset?:  {
    __typename: "Asset",
    id: string,
    title: string,
    type: AssetFileFormat,
    fileFormat: string,
    fileName: string,
    fileSize: string,
    file:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    },
    description?: string | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type UpdateAssetMutationVariables = {
  input: UpdateAssetInput,
  condition?: ModelAssetConditionInput | null,
};

export type UpdateAssetMutation = {
  updateAsset?:  {
    __typename: "Asset",
    id: string,
    title: string,
    type: AssetFileFormat,
    fileFormat: string,
    fileName: string,
    fileSize: string,
    file:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    },
    description?: string | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type DeleteAssetMutationVariables = {
  input: DeleteAssetInput,
  condition?: ModelAssetConditionInput | null,
};

export type DeleteAssetMutation = {
  deleteAsset?:  {
    __typename: "Asset",
    id: string,
    title: string,
    type: AssetFileFormat,
    fileFormat: string,
    fileName: string,
    fileSize: string,
    file:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    },
    description?: string | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type CreateTodoMutationVariables = {
  input: CreateTodoInput,
  condition?: ModelTodoConditionInput | null,
};

export type CreateTodoMutation = {
  createTodo?:  {
    __typename: "Todo",
    id: string,
    name: string,
    description?: string | null,
    image?:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    } | null,
    createdAt: string,
    updatedAt: string,
    owner?: string | null,
  } | null,
};

export type UpdateTodoMutationVariables = {
  input: UpdateTodoInput,
  condition?: ModelTodoConditionInput | null,
};

export type UpdateTodoMutation = {
  updateTodo?:  {
    __typename: "Todo",
    id: string,
    name: string,
    description?: string | null,
    image?:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    } | null,
    createdAt: string,
    updatedAt: string,
    owner?: string | null,
  } | null,
};

export type DeleteTodoMutationVariables = {
  input: DeleteTodoInput,
  condition?: ModelTodoConditionInput | null,
};

export type DeleteTodoMutation = {
  deleteTodo?:  {
    __typename: "Todo",
    id: string,
    name: string,
    description?: string | null,
    image?:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    } | null,
    createdAt: string,
    updatedAt: string,
    owner?: string | null,
  } | null,
};

export type GetAssetQueryVariables = {
  id: string,
};

export type GetAssetQuery = {
  getAsset?:  {
    __typename: "Asset",
    id: string,
    title: string,
    type: AssetFileFormat,
    fileFormat: string,
    fileName: string,
    fileSize: string,
    file:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    },
    description?: string | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type ListAssetsQueryVariables = {
  filter?: ModelAssetFilterInput | null,
  limit?: number | null,
  nextToken?: string | null,
};

export type ListAssetsQuery = {
  listAssets?:  {
    __typename: "ModelAssetConnection",
    items?:  Array< {
      __typename: "Asset",
      id: string,
      title: string,
      type: AssetFileFormat,
      fileFormat: string,
      fileName: string,
      fileSize: string,
      description?: string | null,
      createdAt: string,
      updatedAt: string,
    } | null > | null,
    nextToken?: string | null,
  } | null,
};

export type GetTodoQueryVariables = {
  id: string,
};

export type GetTodoQuery = {
  getTodo?:  {
    __typename: "Todo",
    id: string,
    name: string,
    description?: string | null,
    image?:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    } | null,
    createdAt: string,
    updatedAt: string,
    owner?: string | null,
  } | null,
};

export type ListTodosQueryVariables = {
  filter?: ModelTodoFilterInput | null,
  limit?: number | null,
  nextToken?: string | null,
};

export type ListTodosQuery = {
  listTodos?:  {
    __typename: "ModelTodoConnection",
    items?:  Array< {
      __typename: "Todo",
      id: string,
      name: string,
      description?: string | null,
      createdAt: string,
      updatedAt: string,
      owner?: string | null,
    } | null > | null,
    nextToken?: string | null,
  } | null,
};

export type OnCreateAssetSubscription = {
  onCreateAsset?:  {
    __typename: "Asset",
    id: string,
    title: string,
    type: AssetFileFormat,
    fileFormat: string,
    fileName: string,
    fileSize: string,
    file:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    },
    description?: string | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type OnUpdateAssetSubscription = {
  onUpdateAsset?:  {
    __typename: "Asset",
    id: string,
    title: string,
    type: AssetFileFormat,
    fileFormat: string,
    fileName: string,
    fileSize: string,
    file:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    },
    description?: string | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type OnDeleteAssetSubscription = {
  onDeleteAsset?:  {
    __typename: "Asset",
    id: string,
    title: string,
    type: AssetFileFormat,
    fileFormat: string,
    fileName: string,
    fileSize: string,
    file:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    },
    description?: string | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type OnCreateTodoSubscriptionVariables = {
  owner: string,
};

export type OnCreateTodoSubscription = {
  onCreateTodo?:  {
    __typename: "Todo",
    id: string,
    name: string,
    description?: string | null,
    image?:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    } | null,
    createdAt: string,
    updatedAt: string,
    owner?: string | null,
  } | null,
};

export type OnUpdateTodoSubscriptionVariables = {
  owner: string,
};

export type OnUpdateTodoSubscription = {
  onUpdateTodo?:  {
    __typename: "Todo",
    id: string,
    name: string,
    description?: string | null,
    image?:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    } | null,
    createdAt: string,
    updatedAt: string,
    owner?: string | null,
  } | null,
};

export type OnDeleteTodoSubscriptionVariables = {
  owner: string,
};

export type OnDeleteTodoSubscription = {
  onDeleteTodo?:  {
    __typename: "Todo",
    id: string,
    name: string,
    description?: string | null,
    image?:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    } | null,
    createdAt: string,
    updatedAt: string,
    owner?: string | null,
  } | null,
};
