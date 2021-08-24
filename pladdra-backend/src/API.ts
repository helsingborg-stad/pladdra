/* tslint:disable */
/* eslint-disable */
//  This file was automatically generated and should not be edited.

export type CreateAssetInput = {
  id?: string | null,
  name: string,
  type: AssetType,
  fileFormat: AssetFileFormat,
  fileName: string,
  fileSize: number,
  file: S3ObjectInput,
  description?: string | null,
};

export enum AssetType {
  MESH = "MESH",
}


export enum AssetFileFormat {
  GLTF = "GLTF",
  GLB = "GLB",
  OBJ = "OBJ",
  FBX = "FBX",
  DWG = "DWG",
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
  name?: ModelStringInput | null,
  type?: ModelAssetTypeInput | null,
  fileFormat?: ModelAssetFileFormatInput | null,
  fileName?: ModelStringInput | null,
  fileSize?: ModelIntInput | null,
  description?: ModelStringInput | null,
  createdAt?: ModelStringInput | null,
  updatedAt?: ModelStringInput | null,
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

export type ModelAssetTypeInput = {
  eq?: AssetType | null,
  ne?: AssetType | null,
};

export type ModelAssetFileFormatInput = {
  eq?: AssetFileFormat | null,
  ne?: AssetFileFormat | null,
};

export type ModelIntInput = {
  ne?: number | null,
  eq?: number | null,
  le?: number | null,
  lt?: number | null,
  ge?: number | null,
  gt?: number | null,
  between?: Array< number | null > | null,
  attributeExists?: boolean | null,
  attributeType?: ModelAttributeTypes | null,
};

export type Asset = {
  __typename: "Asset",
  id: string,
  name: string,
  type: AssetType,
  fileFormat: AssetFileFormat,
  fileName: string,
  fileSize: number,
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
  name?: string | null,
  type?: AssetType | null,
  fileFormat?: AssetFileFormat | null,
  fileName?: string | null,
  fileSize?: number | null,
  file?: S3ObjectInput | null,
  description?: string | null,
  createdAt?: string | null,
  updatedAt?: string | null,
};

export type DeleteAssetInput = {
  id: string,
};

export type CreateBlockInput = {
  id?: string | null,
  createdAt?: string | null,
  updatedAt?: string | null,
  workspaceID: string,
  assetID: string,
  position: Vect3Input,
  rotation: QuatInput,
};

export type Vect3Input = {
  x: number,
  y: number,
  z: number,
};

export type QuatInput = {
  x: number,
  y: number,
  z: number,
  w: number,
};

export type ModelBlockConditionInput = {
  createdAt?: ModelStringInput | null,
  updatedAt?: ModelStringInput | null,
  workspaceID?: ModelIDInput | null,
  assetID?: ModelIDInput | null,
  and?: Array< ModelBlockConditionInput | null > | null,
  or?: Array< ModelBlockConditionInput | null > | null,
  not?: ModelBlockConditionInput | null,
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

export type Block = {
  __typename: "Block",
  id: string,
  createdAt: string,
  updatedAt: string,
  workspaceID: string,
  assetID: string,
  position: Vect3,
  rotation: Quat,
  owner?: string | null,
};

export type Vect3 = {
  __typename: "Vect3",
  x: number,
  y: number,
  z: number,
};

export type Quat = {
  __typename: "Quat",
  x: number,
  y: number,
  z: number,
  w: number,
};

export type UpdateBlockInput = {
  id: string,
  createdAt?: string | null,
  updatedAt?: string | null,
  workspaceID?: string | null,
  assetID?: string | null,
  position?: Vect3Input | null,
  rotation?: QuatInput | null,
};

export type DeleteBlockInput = {
  id: string,
};

export type CreateWorkspaceInput = {
  id?: string | null,
  name: string,
  createdAt?: string | null,
  updatedAt?: string | null,
  description?: string | null,
};

export type ModelWorkspaceConditionInput = {
  name?: ModelStringInput | null,
  createdAt?: ModelStringInput | null,
  updatedAt?: ModelStringInput | null,
  description?: ModelStringInput | null,
  and?: Array< ModelWorkspaceConditionInput | null > | null,
  or?: Array< ModelWorkspaceConditionInput | null > | null,
  not?: ModelWorkspaceConditionInput | null,
};

export type Workspace = {
  __typename: "Workspace",
  id: string,
  name: string,
  createdAt: string,
  updatedAt: string,
  description?: string | null,
  blocks?: ModelBlockConnection | null,
  owner?: string | null,
};

export type ModelBlockConnection = {
  __typename: "ModelBlockConnection",
  items?:  Array<Block | null > | null,
  nextToken?: string | null,
};

export type UpdateWorkspaceInput = {
  id: string,
  name?: string | null,
  createdAt?: string | null,
  updatedAt?: string | null,
  description?: string | null,
};

export type DeleteWorkspaceInput = {
  id: string,
};

export type ModelAssetFilterInput = {
  id?: ModelIDInput | null,
  name?: ModelStringInput | null,
  type?: ModelAssetTypeInput | null,
  fileFormat?: ModelAssetFileFormatInput | null,
  fileName?: ModelStringInput | null,
  fileSize?: ModelIntInput | null,
  description?: ModelStringInput | null,
  createdAt?: ModelStringInput | null,
  updatedAt?: ModelStringInput | null,
  and?: Array< ModelAssetFilterInput | null > | null,
  or?: Array< ModelAssetFilterInput | null > | null,
  not?: ModelAssetFilterInput | null,
};

export type ModelAssetConnection = {
  __typename: "ModelAssetConnection",
  items?:  Array<Asset | null > | null,
  nextToken?: string | null,
};

export type ModelAssetByFileFormatCompositeKeyConditionInput = {
  eq?: ModelAssetByFileFormatCompositeKeyInput | null,
  le?: ModelAssetByFileFormatCompositeKeyInput | null,
  lt?: ModelAssetByFileFormatCompositeKeyInput | null,
  ge?: ModelAssetByFileFormatCompositeKeyInput | null,
  gt?: ModelAssetByFileFormatCompositeKeyInput | null,
  between?: Array< ModelAssetByFileFormatCompositeKeyInput | null > | null,
  beginsWith?: ModelAssetByFileFormatCompositeKeyInput | null,
};

export type ModelAssetByFileFormatCompositeKeyInput = {
  createdAt?: string | null,
  updatedAt?: string | null,
};

export enum ModelSortDirection {
  ASC = "ASC",
  DESC = "DESC",
}


export type ModelBlockFilterInput = {
  id?: ModelIDInput | null,
  createdAt?: ModelStringInput | null,
  updatedAt?: ModelStringInput | null,
  workspaceID?: ModelIDInput | null,
  assetID?: ModelIDInput | null,
  and?: Array< ModelBlockFilterInput | null > | null,
  or?: Array< ModelBlockFilterInput | null > | null,
  not?: ModelBlockFilterInput | null,
};

export type ModelWorkspaceFilterInput = {
  id?: ModelIDInput | null,
  name?: ModelStringInput | null,
  createdAt?: ModelStringInput | null,
  updatedAt?: ModelStringInput | null,
  description?: ModelStringInput | null,
  and?: Array< ModelWorkspaceFilterInput | null > | null,
  or?: Array< ModelWorkspaceFilterInput | null > | null,
  not?: ModelWorkspaceFilterInput | null,
};

export type ModelWorkspaceConnection = {
  __typename: "ModelWorkspaceConnection",
  items?:  Array<Workspace | null > | null,
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
    name: string,
    type: AssetType,
    fileFormat: AssetFileFormat,
    fileName: string,
    fileSize: number,
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
    name: string,
    type: AssetType,
    fileFormat: AssetFileFormat,
    fileName: string,
    fileSize: number,
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
    name: string,
    type: AssetType,
    fileFormat: AssetFileFormat,
    fileName: string,
    fileSize: number,
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

export type CreateBlockMutationVariables = {
  input: CreateBlockInput,
  condition?: ModelBlockConditionInput | null,
};

export type CreateBlockMutation = {
  createBlock?:  {
    __typename: "Block",
    id: string,
    createdAt: string,
    updatedAt: string,
    workspaceID: string,
    assetID: string,
    position:  {
      __typename: "Vect3",
      x: number,
      y: number,
      z: number,
    },
    rotation:  {
      __typename: "Quat",
      x: number,
      y: number,
      z: number,
      w: number,
    },
    owner?: string | null,
  } | null,
};

export type UpdateBlockMutationVariables = {
  input: UpdateBlockInput,
  condition?: ModelBlockConditionInput | null,
};

export type UpdateBlockMutation = {
  updateBlock?:  {
    __typename: "Block",
    id: string,
    createdAt: string,
    updatedAt: string,
    workspaceID: string,
    assetID: string,
    position:  {
      __typename: "Vect3",
      x: number,
      y: number,
      z: number,
    },
    rotation:  {
      __typename: "Quat",
      x: number,
      y: number,
      z: number,
      w: number,
    },
    owner?: string | null,
  } | null,
};

export type DeleteBlockMutationVariables = {
  input: DeleteBlockInput,
  condition?: ModelBlockConditionInput | null,
};

export type DeleteBlockMutation = {
  deleteBlock?:  {
    __typename: "Block",
    id: string,
    createdAt: string,
    updatedAt: string,
    workspaceID: string,
    assetID: string,
    position:  {
      __typename: "Vect3",
      x: number,
      y: number,
      z: number,
    },
    rotation:  {
      __typename: "Quat",
      x: number,
      y: number,
      z: number,
      w: number,
    },
    owner?: string | null,
  } | null,
};

export type CreateWorkspaceMutationVariables = {
  input: CreateWorkspaceInput,
  condition?: ModelWorkspaceConditionInput | null,
};

export type CreateWorkspaceMutation = {
  createWorkspace?:  {
    __typename: "Workspace",
    id: string,
    name: string,
    createdAt: string,
    updatedAt: string,
    description?: string | null,
    blocks?:  {
      __typename: "ModelBlockConnection",
      items?:  Array< {
        __typename: "Block",
        id: string,
        createdAt: string,
        updatedAt: string,
        workspaceID: string,
        assetID: string,
        owner?: string | null,
      } | null > | null,
      nextToken?: string | null,
    } | null,
    owner?: string | null,
  } | null,
};

export type UpdateWorkspaceMutationVariables = {
  input: UpdateWorkspaceInput,
  condition?: ModelWorkspaceConditionInput | null,
};

export type UpdateWorkspaceMutation = {
  updateWorkspace?:  {
    __typename: "Workspace",
    id: string,
    name: string,
    createdAt: string,
    updatedAt: string,
    description?: string | null,
    blocks?:  {
      __typename: "ModelBlockConnection",
      items?:  Array< {
        __typename: "Block",
        id: string,
        createdAt: string,
        updatedAt: string,
        workspaceID: string,
        assetID: string,
        owner?: string | null,
      } | null > | null,
      nextToken?: string | null,
    } | null,
    owner?: string | null,
  } | null,
};

export type DeleteWorkspaceMutationVariables = {
  input: DeleteWorkspaceInput,
  condition?: ModelWorkspaceConditionInput | null,
};

export type DeleteWorkspaceMutation = {
  deleteWorkspace?:  {
    __typename: "Workspace",
    id: string,
    name: string,
    createdAt: string,
    updatedAt: string,
    description?: string | null,
    blocks?:  {
      __typename: "ModelBlockConnection",
      items?:  Array< {
        __typename: "Block",
        id: string,
        createdAt: string,
        updatedAt: string,
        workspaceID: string,
        assetID: string,
        owner?: string | null,
      } | null > | null,
      nextToken?: string | null,
    } | null,
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
    name: string,
    type: AssetType,
    fileFormat: AssetFileFormat,
    fileName: string,
    fileSize: number,
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
      name: string,
      type: AssetType,
      fileFormat: AssetFileFormat,
      fileName: string,
      fileSize: number,
      file:  {
        __typename: "S3Object",
        bucket: string,
        key: string,
        region: string,
      },
      description?: string | null,
      createdAt: string,
      updatedAt: string,
    } | null > | null,
    nextToken?: string | null,
  } | null,
};

export type AssetsByFileFormatQueryVariables = {
  fileFormat?: AssetFileFormat | null,
  createdAtUpdatedAt?: ModelAssetByFileFormatCompositeKeyConditionInput | null,
  sortDirection?: ModelSortDirection | null,
  filter?: ModelAssetFilterInput | null,
  limit?: number | null,
  nextToken?: string | null,
};

export type AssetsByFileFormatQuery = {
  assetsByFileFormat?:  {
    __typename: "ModelAssetConnection",
    items?:  Array< {
      __typename: "Asset",
      id: string,
      name: string,
      type: AssetType,
      fileFormat: AssetFileFormat,
      fileName: string,
      fileSize: number,
      file:  {
        __typename: "S3Object",
        bucket: string,
        key: string,
        region: string,
      },
      description?: string | null,
      createdAt: string,
      updatedAt: string,
    } | null > | null,
    nextToken?: string | null,
  } | null,
};

export type GetBlockQueryVariables = {
  id: string,
};

export type GetBlockQuery = {
  getBlock?:  {
    __typename: "Block",
    id: string,
    createdAt: string,
    updatedAt: string,
    workspaceID: string,
    assetID: string,
    position:  {
      __typename: "Vect3",
      x: number,
      y: number,
      z: number,
    },
    rotation:  {
      __typename: "Quat",
      x: number,
      y: number,
      z: number,
      w: number,
    },
    owner?: string | null,
  } | null,
};

export type ListBlocksQueryVariables = {
  filter?: ModelBlockFilterInput | null,
  limit?: number | null,
  nextToken?: string | null,
};

export type ListBlocksQuery = {
  listBlocks?:  {
    __typename: "ModelBlockConnection",
    items?:  Array< {
      __typename: "Block",
      id: string,
      createdAt: string,
      updatedAt: string,
      workspaceID: string,
      assetID: string,
      position:  {
        __typename: "Vect3",
        x: number,
        y: number,
        z: number,
      },
      rotation:  {
        __typename: "Quat",
        x: number,
        y: number,
        z: number,
        w: number,
      },
      owner?: string | null,
    } | null > | null,
    nextToken?: string | null,
  } | null,
};

export type GetWorkspaceQueryVariables = {
  id: string,
};

export type GetWorkspaceQuery = {
  getWorkspace?:  {
    __typename: "Workspace",
    id: string,
    name: string,
    createdAt: string,
    updatedAt: string,
    description?: string | null,
    blocks?:  {
      __typename: "ModelBlockConnection",
      items?:  Array< {
        __typename: "Block",
        id: string,
        createdAt: string,
        updatedAt: string,
        workspaceID: string,
        assetID: string,
        owner?: string | null,
      } | null > | null,
      nextToken?: string | null,
    } | null,
    owner?: string | null,
  } | null,
};

export type ListWorkspacesQueryVariables = {
  filter?: ModelWorkspaceFilterInput | null,
  limit?: number | null,
  nextToken?: string | null,
};

export type ListWorkspacesQuery = {
  listWorkspaces?:  {
    __typename: "ModelWorkspaceConnection",
    items?:  Array< {
      __typename: "Workspace",
      id: string,
      name: string,
      createdAt: string,
      updatedAt: string,
      description?: string | null,
      blocks?:  {
        __typename: "ModelBlockConnection",
        nextToken?: string | null,
      } | null,
      owner?: string | null,
    } | null > | null,
    nextToken?: string | null,
  } | null,
};

export type OnCreateAssetSubscription = {
  onCreateAsset?:  {
    __typename: "Asset",
    id: string,
    name: string,
    type: AssetType,
    fileFormat: AssetFileFormat,
    fileName: string,
    fileSize: number,
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
    name: string,
    type: AssetType,
    fileFormat: AssetFileFormat,
    fileName: string,
    fileSize: number,
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
    name: string,
    type: AssetType,
    fileFormat: AssetFileFormat,
    fileName: string,
    fileSize: number,
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

export type OnCreateBlockSubscriptionVariables = {
  owner?: string | null,
};

export type OnCreateBlockSubscription = {
  onCreateBlock?:  {
    __typename: "Block",
    id: string,
    createdAt: string,
    updatedAt: string,
    workspaceID: string,
    assetID: string,
    position:  {
      __typename: "Vect3",
      x: number,
      y: number,
      z: number,
    },
    rotation:  {
      __typename: "Quat",
      x: number,
      y: number,
      z: number,
      w: number,
    },
    owner?: string | null,
  } | null,
};

export type OnUpdateBlockSubscriptionVariables = {
  owner?: string | null,
};

export type OnUpdateBlockSubscription = {
  onUpdateBlock?:  {
    __typename: "Block",
    id: string,
    createdAt: string,
    updatedAt: string,
    workspaceID: string,
    assetID: string,
    position:  {
      __typename: "Vect3",
      x: number,
      y: number,
      z: number,
    },
    rotation:  {
      __typename: "Quat",
      x: number,
      y: number,
      z: number,
      w: number,
    },
    owner?: string | null,
  } | null,
};

export type OnDeleteBlockSubscriptionVariables = {
  owner?: string | null,
};

export type OnDeleteBlockSubscription = {
  onDeleteBlock?:  {
    __typename: "Block",
    id: string,
    createdAt: string,
    updatedAt: string,
    workspaceID: string,
    assetID: string,
    position:  {
      __typename: "Vect3",
      x: number,
      y: number,
      z: number,
    },
    rotation:  {
      __typename: "Quat",
      x: number,
      y: number,
      z: number,
      w: number,
    },
    owner?: string | null,
  } | null,
};

export type OnCreateWorkspaceSubscriptionVariables = {
  owner?: string | null,
};

export type OnCreateWorkspaceSubscription = {
  onCreateWorkspace?:  {
    __typename: "Workspace",
    id: string,
    name: string,
    createdAt: string,
    updatedAt: string,
    description?: string | null,
    blocks?:  {
      __typename: "ModelBlockConnection",
      items?:  Array< {
        __typename: "Block",
        id: string,
        createdAt: string,
        updatedAt: string,
        workspaceID: string,
        assetID: string,
        owner?: string | null,
      } | null > | null,
      nextToken?: string | null,
    } | null,
    owner?: string | null,
  } | null,
};

export type OnUpdateWorkspaceSubscriptionVariables = {
  owner?: string | null,
};

export type OnUpdateWorkspaceSubscription = {
  onUpdateWorkspace?:  {
    __typename: "Workspace",
    id: string,
    name: string,
    createdAt: string,
    updatedAt: string,
    description?: string | null,
    blocks?:  {
      __typename: "ModelBlockConnection",
      items?:  Array< {
        __typename: "Block",
        id: string,
        createdAt: string,
        updatedAt: string,
        workspaceID: string,
        assetID: string,
        owner?: string | null,
      } | null > | null,
      nextToken?: string | null,
    } | null,
    owner?: string | null,
  } | null,
};

export type OnDeleteWorkspaceSubscriptionVariables = {
  owner?: string | null,
};

export type OnDeleteWorkspaceSubscription = {
  onDeleteWorkspace?:  {
    __typename: "Workspace",
    id: string,
    name: string,
    createdAt: string,
    updatedAt: string,
    description?: string | null,
    blocks?:  {
      __typename: "ModelBlockConnection",
      items?:  Array< {
        __typename: "Block",
        id: string,
        createdAt: string,
        updatedAt: string,
        workspaceID: string,
        assetID: string,
        owner?: string | null,
      } | null > | null,
      nextToken?: string | null,
    } | null,
    owner?: string | null,
  } | null,
};
