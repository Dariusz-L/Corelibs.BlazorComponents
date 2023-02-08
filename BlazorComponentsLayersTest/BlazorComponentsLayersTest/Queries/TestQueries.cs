using PageTree.App.Entities.Styles;

namespace BlazorComponentsLayersTest.Queries
{
    public static class TestQueries
    {
        public static GetPageQueryOut Query = new(
            new()
            {
                Identity = new() { ID = "Japanese-Language-ID", Name = "Japanese Language" },
                Path = new IdentityVM[] { new() { ID = "Project-ID", Name = "Project" } },
                Properties = new PropertyVM[]
                {
                    new()
                    {
                        Identity = new() { ID = "Authors-ID", Name = "Authors" },
                        SignatureIdentity = new() { ID = "Authors-Signature-ID", Name = "Authors" },
                        Properties = new PropertyVM[]
                        {
                            new()
                            {
                                IsExpanded = false,
                                Identity = new() { ID = "Misa-Ammo-1-ID", Name = "Misa Ammo" },
                                SignatureIdentity = new() { ID = "Author-Signature-ID", Name = "Author" },
                                Properties = new PropertyVM[]
                                {
                                    new()
                                    {
                                        Identity = new() { ID = "An-ID", Name = "Lessons" },
                                        SignatureIdentity = new() { ID = "Lessons-Signature-ID", Name = "Lessons" },
                                        Properties = new PropertyVM[]
                                        {
                                            new()
                                            {
                                                Identity = new() { ID = "An-ID", Name = "Lesson 1" },
                                                SignatureIdentity = new() { ID = "Lesson-Signature-ID", Name = "Lesson" },
                                                Properties = new PropertyVM[]
                                                {
                                                    new()
                                                    {
                                                        Identity = new() { Name = "長いレッスンになる。" },
                                                        SignatureIdentity = new() { Name = "Phrase" },
                                                        Properties = new PropertyVM[]
                                                        {
                                                            new()
                                                            {
                                                                Identity = new() { Name = "Meanings" },
                                                                SignatureIdentity = new() { Name = "Meanings" },
                                                                Properties = new PropertyVM[]
                                                                {
                                                                    new()
                                                                    {
                                                                        Identity = new() { Name = "It's going to be a long lesson." },
                                                                        SignatureIdentity = new() { Name = "Meaning Value" },
                                                                    }
                                                                }
                                                            },
                                                            new()
                                                            {
                                                                Identity = new() { Name = "Hiragana Writing" },
                                                                SignatureIdentity = new() { Name = "Hiragana Writing" },
                                                            },
                                                            new()
                                                            {
                                                                Identity = new() { Name = "Words" },
                                                                SignatureIdentity = new() { Name = "Words" },
                                                                Properties = new PropertyVM[]
                                                                {
                                                                    new()
                                                                    {
                                                                        Identity = new() { Name = "長い" },
                                                                        SignatureIdentity = new() { Name = "Word" },
                                                                        Properties = new PropertyVM[]
                                                                        {
                                                                            new()
                                                                            {
                                                                                Identity = new() { Name = "long" },
                                                                                SignatureIdentity = new() { Name = "Meaning Value" },
                                                                            }
                                                                        }
                                                                    },
                                                                    new()
                                                                    {
                                                                        Identity = new() { Name = "レッスン" },
                                                                        SignatureIdentity = new() { Name = "Word" },
                                                                        Properties = new PropertyVM[]
                                                                        {
                                                                            new()
                                                                            {
                                                                                Identity = new() { Name = "lesson" },
                                                                                SignatureIdentity = new() { Name = "Meaning Value" },
                                                                            }
                                                                        }
                                                                    },
                                                                    new()
                                                                    {
                                                                        Identity = new() { Name = "に" },
                                                                        SignatureIdentity = new() { Name = "Word" },
                                                                        Properties = new PropertyVM[]
                                                                        {
                                                                            new()
                                                                            {
                                                                                Identity = new() { Name = "Object of a verb" },
                                                                                SignatureIdentity = new() { Name = "Meaning Value" },
                                                                            }
                                                                        }
                                                                    },
                                                                }
                                                            },
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new()
                    {
                        Identity = new() { ID = "Words-ID", Name = "Words" },
                        SignatureIdentity = new() { ID = "Words-Signature-ID", Name = "Words" },
                        Properties = new PropertyVM[]
                        {
                            new()
                            {
                                Identity = new() { ID = "Nouns-1-ID", Name = "Nouns" },
                                SignatureIdentity = new() { ID = "Nouns-Signature-ID", Name = "Nouns" },
                            },
                            new()
                            {
                                Identity = new() { ID = "Verbs-1-ID", Name = "Verbs" },
                                SignatureIdentity = new() { ID = "Verbs-Signature-ID", Name = "Verbs" },
                            }
                        }
                    }
                },

                StyleOfPage = new()
                {
                    RootProperty = new()
                    {
                        ChildrenStyle = new()
                        {
                            new()
                            {
                                Type = PageTree.App.Entities.Styles.StyleArtifactType.Name,
                                VisualInfo = new()
                                {
                                    Font = new()
                                    {
                                        FontSize = 18
                                    }
                                }
                            }
                        },
                        Children = new()
                        {
                            new()
                            {
                                StyleType = ApplyStyleBy.Index,
                                ChildIndex = 0,
                                VisualInfo = new()
                                {
                                    Font = new()
                                    {
                                        FontSize = 30
                                    }
                                },
                                Artifacts = new()
                                {
                                    new()
                                    {
                                        Type = PageTree.App.Entities.Styles.StyleArtifactType.Signature,
                                        VisualInfo = new()
                                        {
                                            Font = new()
                                            {
                                                FontSize = 8
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
    }
}
